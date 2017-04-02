namespace EncryptorGUI
{
  partial class Form1
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
      this.btnRemove = new System.Windows.Forms.Button();
      this.btnAdd = new System.Windows.Forms.Button();
      this.rdioDecrypt = new System.Windows.Forms.RadioButton();
      this.rdioEncrypt = new System.Windows.Forms.RadioButton();
      this.txtOutput = new System.Windows.Forms.TextBox();
      this.txtInput = new System.Windows.Forms.TextBox();
      this.lstSelected = new System.Windows.Forms.ListBox();
      this.lstAvailable = new System.Windows.Forms.ListBox();
      this.btnSwitch = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnRemove
      // 
      this.btnRemove.Location = new System.Drawing.Point(12, 257);
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.Size = new System.Drawing.Size(168, 23);
      this.btnRemove.TabIndex = 15;
      this.btnRemove.Text = "Remove";
      this.btnRemove.UseVisualStyleBackColor = true;
      // 
      // btnAdd
      // 
      this.btnAdd.Location = new System.Drawing.Point(12, 127);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(168, 23);
      this.btnAdd.TabIndex = 16;
      this.btnAdd.Text = "Add";
      this.btnAdd.UseVisualStyleBackColor = true;
      // 
      // rdioDecrypt
      // 
      this.rdioDecrypt.AutoSize = true;
      this.rdioDecrypt.Location = new System.Drawing.Point(392, 139);
      this.rdioDecrypt.Name = "rdioDecrypt";
      this.rdioDecrypt.Size = new System.Drawing.Size(62, 17);
      this.rdioDecrypt.TabIndex = 11;
      this.rdioDecrypt.Text = "Decrypt";
      this.rdioDecrypt.UseVisualStyleBackColor = true;
      // 
      // rdioEncrypt
      // 
      this.rdioEncrypt.AutoSize = true;
      this.rdioEncrypt.Checked = true;
      this.rdioEncrypt.Location = new System.Drawing.Point(392, 116);
      this.rdioEncrypt.Name = "rdioEncrypt";
      this.rdioEncrypt.Size = new System.Drawing.Size(61, 17);
      this.rdioEncrypt.TabIndex = 12;
      this.rdioEncrypt.TabStop = true;
      this.rdioEncrypt.Text = "Encrypt";
      this.rdioEncrypt.UseVisualStyleBackColor = true;
      // 
      // txtOutput
      // 
      this.txtOutput.Location = new System.Drawing.Point(460, 26);
      this.txtOutput.Multiline = true;
      this.txtOutput.Name = "txtOutput";
      this.txtOutput.ReadOnly = true;
      this.txtOutput.Size = new System.Drawing.Size(200, 254);
      this.txtOutput.TabIndex = 9;
      // 
      // txtInput
      // 
      this.txtInput.Location = new System.Drawing.Point(186, 26);
      this.txtInput.Multiline = true;
      this.txtInput.Name = "txtInput";
      this.txtInput.Size = new System.Drawing.Size(200, 254);
      this.txtInput.TabIndex = 10;
      // 
      // lstSelected
      // 
      this.lstSelected.FormattingEnabled = true;
      this.lstSelected.Items.AddRange(new object[] {
            ""});
      this.lstSelected.Location = new System.Drawing.Point(12, 156);
      this.lstSelected.Name = "lstSelected";
      this.lstSelected.Size = new System.Drawing.Size(168, 95);
      this.lstSelected.TabIndex = 7;
      // 
      // lstAvailable
      // 
      this.lstAvailable.FormattingEnabled = true;
      this.lstAvailable.Location = new System.Drawing.Point(12, 26);
      this.lstAvailable.Name = "lstAvailable";
      this.lstAvailable.Size = new System.Drawing.Size(168, 95);
      this.lstAvailable.TabIndex = 8;
      // 
      // btnSwitch
      // 
      this.btnSwitch.Location = new System.Drawing.Point(392, 162);
      this.btnSwitch.Name = "btnSwitch";
      this.btnSwitch.Size = new System.Drawing.Size(60, 23);
      this.btnSwitch.TabIndex = 17;
      this.btnSwitch.Text = "<<<";
      this.btnSwitch.UseVisualStyleBackColor = true;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(679, 304);
      this.Controls.Add(this.btnSwitch);
      this.Controls.Add(this.btnRemove);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.rdioDecrypt);
      this.Controls.Add(this.rdioEncrypt);
      this.Controls.Add(this.txtOutput);
      this.Controls.Add(this.txtInput);
      this.Controls.Add(this.lstSelected);
      this.Controls.Add(this.lstAvailable);
      this.Name = "Form1";
      this.Text = "Encryptorizer GUI";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.RadioButton rdioDecrypt;
    private System.Windows.Forms.RadioButton rdioEncrypt;
    private System.Windows.Forms.TextBox txtOutput;
    private System.Windows.Forms.TextBox txtInput;
    private System.Windows.Forms.ListBox lstSelected;
    private System.Windows.Forms.ListBox lstAvailable;
    private System.Windows.Forms.Button btnSwitch;
  }
}

