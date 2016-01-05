namespace UserInterface
{
    partial class DeleteOrEditTaskForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TaskIDLabel = new System.Windows.Forms.Label();
            this.SendEmailCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.IssueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DetailsTextBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TaskTitleTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AssignedToComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AssignedByLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task ID:";
            // 
            // TaskIDLabel
            // 
            this.TaskIDLabel.AutoSize = true;
            this.TaskIDLabel.Location = new System.Drawing.Point(99, 13);
            this.TaskIDLabel.Name = "TaskIDLabel";
            this.TaskIDLabel.Size = new System.Drawing.Size(0, 13);
            this.TaskIDLabel.TabIndex = 1;
            // 
            // SendEmailCheckBox
            // 
            this.SendEmailCheckBox.AutoSize = true;
            this.SendEmailCheckBox.Location = new System.Drawing.Point(98, 224);
            this.SendEmailCheckBox.Name = "SendEmailCheckBox";
            this.SendEmailCheckBox.Size = new System.Drawing.Size(79, 17);
            this.SendEmailCheckBox.TabIndex = 27;
            this.SendEmailCheckBox.Text = "Send Email";
            this.SendEmailCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(128, 247);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(89, 31);
            this.SaveButton.TabIndex = 26;
            this.SaveButton.Text = "Save Changes";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DueDatePicker
            // 
            this.DueDatePicker.Location = new System.Drawing.Point(98, 194);
            this.DueDatePicker.Name = "DueDatePicker";
            this.DueDatePicker.Size = new System.Drawing.Size(200, 20);
            this.DueDatePicker.TabIndex = 25;
            // 
            // IssueDatePicker
            // 
            this.IssueDatePicker.Location = new System.Drawing.Point(98, 167);
            this.IssueDatePicker.Name = "IssueDatePicker";
            this.IssueDatePicker.Size = new System.Drawing.Size(200, 20);
            this.IssueDatePicker.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Due Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Issue Date:";
            // 
            // DetailsTextBox
            // 
            this.DetailsTextBox.Location = new System.Drawing.Point(98, 108);
            this.DetailsTextBox.Name = "DetailsTextBox";
            this.DetailsTextBox.Size = new System.Drawing.Size(200, 48);
            this.DetailsTextBox.TabIndex = 21;
            this.DetailsTextBox.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Task Details:";
            // 
            // TaskTitleTextBox
            // 
            this.TaskTitleTextBox.Location = new System.Drawing.Point(98, 81);
            this.TaskTitleTextBox.Name = "TaskTitleTextBox";
            this.TaskTitleTextBox.Size = new System.Drawing.Size(200, 20);
            this.TaskTitleTextBox.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Task Title:";
            // 
            // AssignedToComboBox
            // 
            this.AssignedToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssignedToComboBox.FormattingEnabled = true;
            this.AssignedToComboBox.Location = new System.Drawing.Point(98, 55);
            this.AssignedToComboBox.Name = "AssignedToComboBox";
            this.AssignedToComboBox.Size = new System.Drawing.Size(200, 21);
            this.AssignedToComboBox.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Assigned To:";
            // 
            // AssignedByLabel
            // 
            this.AssignedByLabel.AutoSize = true;
            this.AssignedByLabel.Location = new System.Drawing.Point(99, 35);
            this.AssignedByLabel.Name = "AssignedByLabel";
            this.AssignedByLabel.Size = new System.Drawing.Size(0, 13);
            this.AssignedByLabel.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Assigned By:";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(34, 247);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 31);
            this.DeleteButton.TabIndex = 28;
            this.DeleteButton.Text = "Delete Task";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(234, 247);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 31);
            this.CancelButton.TabIndex = 29;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // DeleteOrEditTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 290);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SendEmailCheckBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DueDatePicker);
            this.Controls.Add(this.IssueDatePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DetailsTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TaskTitleTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AssignedToComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AssignedByLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TaskIDLabel);
            this.Controls.Add(this.label1);
            this.Name = "DeleteOrEditTaskForm";
            this.Text = "DeleteOrEditTaskForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TaskIDLabel;
        private System.Windows.Forms.CheckBox SendEmailCheckBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DateTimePicker DueDatePicker;
        private System.Windows.Forms.DateTimePicker IssueDatePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox DetailsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TaskTitleTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox AssignedToComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label AssignedByLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CancelButton;
    }
}