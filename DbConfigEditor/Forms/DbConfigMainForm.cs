using CryptoLib;
using DbConfigEditor.Models;
using DbConfigEditor.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbConfigEditor.Forms
{
    public partial class DbConfigMainForm : Form
    {
        /// <summary>
        /// 데이터 조회 대상 db주소
        /// </summary>
        public string SourceAddress { get => txtSourceAddr.Text; private set => txtSourceAddr.Text = value; }

        /// <summary>
        /// 데이터 조회 대상 db명
        /// </summary>
        public string SourceDbName { get => txtSourceDbName.Text; private set => txtSourceDbName.Text = value; }

        /// <summary>
        /// 데이터 조회 대상 db 로그인ID
        /// </summary>
        public string SourceLoginId { get => txtSourceId.Text; private set => txtSourceId.Text = value; }

        /// <summary>
        /// 데이터 조회 대상 db 접속 비밀번호
        /// </summary>
        public string SourcePassword { get => txtSourcePassword.Text; private set => txtSourcePassword.Text = value; }

        /// <summary>
        /// 데이터 저장 db주소
        /// </summary>
        public string TargetAddress { get => txtTargetAddr.Text; private set => txtTargetAddr.Text = value; }

        /// <summary>
        /// 데이터 저장 db명
        /// </summary>
        public string TargetDbName { get => txtTargetDbName.Text; private set => txtTargetDbName.Text = value; }

        /// <summary>
        /// 데이터 저장 db 로그인ID
        /// </summary>
        public string TargetLoginId { get => txtTargetId.Text; private set => txtTargetId.Text = value; }

        /// <summary>
        /// 데이터 저장 db 접속 비밀번호
        /// </summary>
        public string TargetPassword { get => txtTargetPassword.Text; private set => txtTargetPassword.Text = value; }

        public DbConfigMainForm()
        {
            InitializeComponent();

            btnClose.Click += (s,e) => { this.Close(); };
            btnSave.Click += BtnSave_Click;
            btnKeygen.Click += BtnKeygen_Click;
        }

        private void BtnKeygen_Click(object? sender, EventArgs e)
        {
            try
            {
                string keyFilePath = PathResolver.GetConfigPath("cryptoKeys.xml");

                CryptoKeyGenerator.GenerateKeyFile(keyFilePath);

                MessageBox.Show("키 파일 생성 완료!\n\n" + keyFilePath, "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"키 생성 중 오류 발생: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            // ProdGatheringApp과 동일한 경로로 keyfile 맞춤
            string keyFile = PathResolver.GetConfigPath("cryptoKeys.xml");

            if (!File.Exists(keyFile))
            {
                MessageBox.Show("암호화 키 파일이 없습니다. 먼저 키를 생성해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //db 정보 저장
            var config = new DbConfig();

            string sourceConn = ConnectionStringBuilder.Build(SourceAddress, SourceDbName, SourceLoginId, SourcePassword);
            string targetConn = ConnectionStringBuilder.Build(TargetAddress, TargetDbName, TargetLoginId, TargetPassword); 

            config.ConnectionStrings["Source"] = CryptoHelper.EncryptString(sourceConn, keyFile);
            config.ConnectionStrings["Target"] = CryptoHelper.EncryptString(targetConn, keyFile);


            string jsonPath = PathResolver.GetConfigPath("dbConfig.json");
            File.WriteAllText(jsonPath, JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true }));

            MessageBox.Show("DB 설정이 저장되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
