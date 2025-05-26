namespace Kadri_AVZ
{
    partial class AccountantForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            salaryGridView = new System.Windows.Forms.DataGridView();
            AddSalary = new System.Windows.Forms.Button();
            textBoxSalary = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)salaryGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // salaryGridView
            // 
            salaryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            salaryGridView.Location = new System.Drawing.Point(12, 55);
            salaryGridView.Name = "salaryGridView";
            salaryGridView.Size = new System.Drawing.Size(765, 531);
            salaryGridView.TabIndex = 0;
            // 
            // AddSalary
            // 
            AddSalary.Cursor = System.Windows.Forms.Cursors.Hand;
            AddSalary.Location = new System.Drawing.Point(783, 95);
            AddSalary.Name = "AddSalary";
            AddSalary.Size = new System.Drawing.Size(132, 23);
            AddSalary.TabIndex = 3;
            AddSalary.Text = "Добавить зарплату";
            AddSalary.UseVisualStyleBackColor = true;
            AddSalary.Click += AddSalary_Click_1;
            // 
            // textBoxSalary
            // 
            textBoxSalary.Location = new System.Drawing.Point(783, 66);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new System.Drawing.Size(132, 23);
            textBoxSalary.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label2.Location = new System.Drawing.Point(783, 39);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(76, 21);
            label2.TabIndex = 4;
            label2.Text = "Зарплата";
            // 
            // button3
            // 
            button3.Cursor = System.Windows.Forms.Cursors.Hand;
            button3.Location = new System.Drawing.Point(135, 31);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(133, 23);
            button3.TabIndex = 7;
            button3.Text = "Обновить таблицу";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem1 });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1164, 24);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(147, 20);
            toolStripMenuItem1.Text = "На вкладку сотрудники";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            label1.ForeColor = System.Drawing.SystemColors.ControlText;
            label1.Location = new System.Drawing.Point(12, 27);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(117, 25);
            label1.TabIndex = 9;
            label1.Text = "Сотрудники";
            // 
            // AccountantForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
            ClientSize = new System.Drawing.Size(1164, 598);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(textBoxSalary);
            Controls.Add(label2);
            Controls.Add(AddSalary);
            Controls.Add(salaryGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AccountantForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Бухгалтерия";
            Load += AccountantForm_Load;
            ((System.ComponentModel.ISupportInitialize)salaryGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView salaryGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox employeeIdTextBox;
        private System.Windows.Forms.Button AddSalary;
        private System.Windows.Forms.TextBox textBoxSalary;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}