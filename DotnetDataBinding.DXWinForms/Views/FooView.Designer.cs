namespace DotnetDataBinding.DXWinForms.Views
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
            btnAlert = new DevExpress.XtraEditors.SimpleButton();
            txtName = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).BeginInit();
            SuspendLayout();
            // 
            // btnAlert
            // 
            btnAlert.Location = new Point(133, 109);
            btnAlert.Name = "btnAlert";
            btnAlert.TabIndex = 0;
            btnAlert.Text = "Alert";
            // 
            // txtName
            // 
            txtName.Location = new Point(133, 83);
            txtName.Name = "txtName";
            txtName.TabIndex = 1;
            // 
            // labelControl1
            // 
            labelControl1.Location = new Point(100, 86);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new Size(27, 13);
            labelControl1.TabIndex = 2;
            labelControl1.Text = "Name";
            // 
            // FooView
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelControl1);
            Controls.Add(txtName);
            Controls.Add(btnAlert);
            Name = "FooView";
            Size = new Size(522, 328);
            ((System.ComponentModel.ISupportInitialize)txtName.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAlert;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
