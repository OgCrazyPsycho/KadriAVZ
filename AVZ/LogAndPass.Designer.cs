namespace Kadri_AVZ
{
    partial class LogAndPass
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            loginTextBox = new System.Windows.Forms.TextBox();
            passwordTextBox = new System.Windows.Forms.TextBox();
            EnterButton = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            label1.Location = new System.Drawing.Point(38, 32);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(359, 29);
            label1.TabIndex = 0;
            label1.Text = "Авторизируйтесь в систему";
            // 
            // loginTextBox
            // 
            loginTextBox.Location = new System.Drawing.Point(129, 114);
            loginTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loginTextBox.Name = "loginTextBox";
            loginTextBox.Size = new System.Drawing.Size(182, 23);
            loginTextBox.TabIndex = 1;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new System.Drawing.Point(129, 179);
            passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new System.Drawing.Size(182, 23);
            passwordTextBox.TabIndex = 2;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // EnterButton
            // 
            EnterButton.BackColor = System.Drawing.Color.LightGreen;
            EnterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            EnterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            EnterButton.Location = new System.Drawing.Point(136, 224);
            EnterButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new System.Drawing.Size(167, 46);
            EnterButton.TabIndex = 3;
            EnterButton.Text = "Войти";
            EnterButton.UseVisualStyleBackColor = false;
            EnterButton.Click += EnterButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            label2.Location = new System.Drawing.Point(20, 114);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(69, 24);
            label2.TabIndex = 4;
            label2.Text = "Логин";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            label3.Location = new System.Drawing.Point(20, 179);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(82, 24);
            label3.TabIndex = 5;
            label3.Text = "Пароль";
            // 
            // LogAndPass
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.PeachPuff;
            ClientSize = new System.Drawing.Size(424, 309);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(EnterButton);
            Controls.Add(passwordTextBox);
            Controls.Add(loginTextBox);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LogAndPass";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "AVZ";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

