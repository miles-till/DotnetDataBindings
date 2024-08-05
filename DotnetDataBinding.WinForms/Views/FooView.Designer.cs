namespace DotnetDataBinding.Views
{
    partial class FooView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtName = new TextBox();
            label1 = new Label();
            btnAlert = new Button();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(68, 50);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 53);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // btnAlert
            // 
            btnAlert.Location = new Point(68, 79);
            btnAlert.Name = "btnAlert";
            btnAlert.Size = new Size(75, 23);
            btnAlert.TabIndex = 2;
            btnAlert.Text = "Alert";
            btnAlert.UseVisualStyleBackColor = true;
            // 
            // FooView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAlert);
            Controls.Add(label1);
            Controls.Add(txtName);
            Name = "FooView";
            Size = new Size(505, 230);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label label1;
        private Button btnAlert;
    }
}
