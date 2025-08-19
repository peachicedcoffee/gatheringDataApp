using ProdGatheringApp.Services;
using ProdGatheringApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProdGatheringApp.Forms
{
    public partial class GatheringMainForm : Form
    {
        private static Mutex? _mutex;

        private GatheringService _gatheringService; 
        private CancellationTokenSource _cts;
        private bool _isRunning;

        public GatheringMainForm()
        {
            InitializeComponent();

            InitService();

            AddEventhandlers();
        }


        #region form events

        private void GatheringMainForm_Load(object? sender, EventArgs e)
        {
            CheckMutex();
            UpdateButtonStates(false);
        }

        private void BtnEnd_Click(object? sender, EventArgs e)
        {
            Logger.Log("info", "프로그램 종료 버튼 클릭");
            Close();
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            Logger.Log("info", "로그 화면 지우기");
        }

        private void BtnStop_Click(object? sender, EventArgs e)
        {
            if (!_isRunning)
            {
                Logger.Log("warn", "중지할 작업이 없습니다.");
                return;
            }

            Logger.Log("info", "데이터 수집 중지");
            _cts?.Cancel();
            _isRunning = false;

            UpdateButtonStates(false);
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            if (_isRunning)
            {
                Logger.Log("warn", "이미 데이터 수집이 실행 중입니다.");
                return;
            }

            Logger.Log("info", "데이터 수집 시작");
            _isRunning = true;
            _cts = new CancellationTokenSource();

            UpdateButtonStates(true);

            Task.Run(() => GatheringLoopAsync(_cts.Token));
        }

        /// <summary>
        /// 필수로직이므로 이벤트 핸들러로 추가하지 않고 오버라이드 합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _mutex?.ReleaseMutex();
            _mutex?.Dispose();
        }

        #endregion


        #region methods

        /// <summary>
        /// db 정보를 읽어온 후 개더링 서비스를 초기화합니다
        /// </summary>
        private void InitService()
        {
            // DB 설정 로드
            var dbConfig = DbConfigLoader.Load();
            if (!dbConfig.ConnectionStrings.ContainsKey("Source") ||
                !dbConfig.ConnectionStrings.ContainsKey("Target"))
            {
                Logger.Log("error", "DB 설정에 Source 또는 Target 연결 정보가 없습니다.");
                return;
            }

            Logger.Log("info", "DB 설정 로드 완료");

            string sourceConn = dbConfig.ConnectionStrings["Source"];
            string targetConn = dbConfig.ConnectionStrings["Target"];

            _gatheringService = new GatheringService(sourceConn, targetConn);
        }

        /// <summary>
        /// 이벤트 핸들러를 등록합니다.
        /// </summary>
        private void AddEventhandlers()
        {
            Logger.LogAppended += log => AppendLog(log);

            Load += GatheringMainForm_Load;
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            btnClear.Click += BtnClear_Click;
            btnEnd.Click += BtnEnd_Click;
        }

        /// <summary>
        /// 중복 실행을 확인합니다. 중복 실행 시 종료.
        /// </summary>
        private static void CheckMutex()
        {
            bool createdNew;
            _mutex = new Mutex(true, "ProdGatheringApp_Mutex", out createdNew);
            if (!createdNew)
            {
                MessageBox.Show("이미 프로그램이 실행 중입니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 데이터 수집을 반복 실행합니다
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task GatheringLoopAsync(CancellationToken token)
        {
            try
            {
                while (!IsDisposed && !token.IsCancellationRequested)
                {
                    await RunGatheringAsync();
                    await Task.Delay(TimeSpan.FromMinutes(1), token);
                }
            }
            catch (TaskCanceledException)
            {
                // 무시
            }
            finally
            {
                //수집 작업이 취소되면 isRunning 상태 변경
                _isRunning = false;
            }

        }

        /// <summary>
        /// 데이터 수집
        /// </summary>
        /// <returns></returns>
        private async Task RunGatheringAsync()
        {
            try
            {
                await _gatheringService.RunAsync();
                Logger.Log("info", "데이터 수집 완료");
            }
            catch (Exception ex)
            {
                Logger.Log("error", $"데이터 수집 중 오류 발생: {ex.Message}");
            }
        }

        /// <summary>
        /// 로그를 기록할 때 textbox에도 보여줍니다
        /// </summary>
        /// <param name="message"></param>
        private void AppendLog(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AppendLog(message)));
                return;
            }

            textBox1.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
        }

        /// <summary>
        /// 프로그램 진행 상황에 따라 버튼 색상을 변경합니다.
        /// </summary>
        /// <param name="isRunning"></param>
        private void UpdateButtonStates(bool isRunning)
        {
            btnStart.Enabled = !isRunning;
            btnStop.Enabled = isRunning;

            btnStart.BackColor = isRunning ? Color.Gray : Color.LightGreen;
            btnStop.BackColor = isRunning ? Color.Red : Color.Gray;

            // 종료, 지우기 버튼은 항상 활성 상태 유지
            btnClear.BackColor = Color.LightBlue;
            btnEnd.BackColor = Color.LightCoral;
        }

        #endregion

    }
}
