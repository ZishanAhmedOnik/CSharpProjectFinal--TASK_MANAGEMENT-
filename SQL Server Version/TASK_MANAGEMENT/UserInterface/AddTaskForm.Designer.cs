namespace UserInterface
{
    partial class AddTaskForm
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
            this.AssignedByLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AssignedToComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TaskTitleTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DetailsTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.IssueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.DueDatePicker = new System.Windows.Forms.DateTimePicker();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SendEmailCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assigned By:";
            // 
            // AssignedByLabel
            // 
            this.AssignedByLabel.AutoSize = true;
            this.AssignedByLabel.Location = new System.Drawing.Point(125, 29);
            this.AssignedByLabel.Name = "AssignedByLabel";
            this.AssignedByLabel.Size = new System.Drawing.Size(0, 13);
            this.AssignedByLabel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Assigned To:";
            // 
            // AssignedToComboBox
            // 
            this.AssignedToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssignedToComboBox.FormattingEnabled = true;
            this.AssignedToComboBox.Location = new System.Drawing.Point(124, 49);
            this.AssignedToComboBox.Name = "AssignedToComboBox";
            this.AssignedToComboBox.Size = new System.Drawing.Size(200, 21);
            this.AssignedToComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Task Title:";
            // 
            // TaskTitleTextBox
            // 
            this.TaskTitleTextBox.Location = new System.Drawing.Point(124, 75);
            this.TaskTitleTextBox.Name = "TaskTitleTextBox";
            this.TaskTitleTextBox.Size = new System.Drawing.Size(200, 20);
            this.TaskTitleTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Task Details:";
            // 
            // DetailsTextBox
            // 
            this.DetailsTextBox.Location = new System.Drawing.Point(124, 102);
            this.DetailsTextBox.Name = "DetailsTextBox";
            this.DetailsTextBox.Size = new System.Drawing.Size(200, 48);
            this.DetailsTextBox.TabIndex = 7;
            this.DetailsTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Issue Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Due Date:";
            // 
            // IssueDatePicker
            // 
            this.IssueDatePicker.Location = new System.Drawing.Point(124, 161);
            this.IssueDatePicker.Name = "IssueDatePicker";
            this.IssueDatePicker.Size = new System.Drawing.Size(200, 20);
            this.IssueDatePicker.TabIndex = 10;
            // 
            // DueDatePicker
            // 
            this.DueDatePicker.Location = new System.Drawing.Point(124, 188);
            this.DueDatePicker.Name = "DueDatePicker";
            this.DueDatePicker.Size = new System.Drawing.Size(200, 20);
            this.DueDatePicker.TabIndex = 11;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(124, 241);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SendEmailCheckBox
            // 
            this.SendEmailCheckBox.AutoSize = true;
            this.SendEmailCheckBox.Location = new System.Drawing.Point(124, 218);
            this.SendEmailCheckBox.Name = "SendEmailCheckBox";
            this.SendEmailCheckBox.Size = new System.Drawing.Size(79, 17);
            this.SendEmailCheckBox.TabIndex = 13;
            this.SendEmailCheckBox.Text = "Send Email";
            this.SendEmailCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 276);
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
            this.Controls.Add(this.label1);
            this.Name = "AddTaskForm";
            this.Text = "AddTaskForm";
            this.Load += new System.EventHandler(this.AddTaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label AssignedByLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox AssignedToComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TaskTitleTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox DetailsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker IssueDatePicker;
        private System.Windows.Forms.DateTimePicker DueDatePicker;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox SendEmailCheckBox;
    }
}