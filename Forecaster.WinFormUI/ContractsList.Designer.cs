using System.Windows.Forms;

namespace Forecaster.WinFormUI
{
    partial class frmContracts
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
            this.gridViewContracts = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTotalContractedVolume = new System.Windows.Forms.Button();
            this.txtContractId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtClientId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewContracts)).BeginInit();
            this.SuspendLayout();
            // 
            // gridViewContracts
            // 
            this.gridViewContracts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridViewContracts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ClientId,
            this.StartDate,
            this.EndDate});
            this.gridViewContracts.Location = new System.Drawing.Point(9, 247);
            this.gridViewContracts.MultiSelect = false;
            this.gridViewContracts.Name = "gridViewContracts";
            this.gridViewContracts.Size = new System.Drawing.Size(546, 150);
            this.gridViewContracts.TabIndex = 0;
            this.gridViewContracts.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridViewContracts_RowHeaderMouseClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Contract Id";
            this.Id.Name = "Id";
            // 
            // ClientId
            // 
            this.ClientId.DataPropertyName = "ClientId";
            this.ClientId.HeaderText = "Client Id";
            this.ClientId.Name = "ClientId";
            // 
            // StartDate
            // 
            this.StartDate.DataPropertyName = "StartDate";
            this.StartDate.HeaderText = "Contract StartDate";
            this.StartDate.Name = "StartDate";
            // 
            // EndDate
            // 
            this.EndDate.DataPropertyName = "EndDate";
            this.EndDate.HeaderText = "Contract EndDate";
            this.EndDate.Name = "EndDate";
            // 
            // btnTotalContractedVolume
            // 
            this.btnTotalContractedVolume.Location = new System.Drawing.Point(103, 202);
            this.btnTotalContractedVolume.Name = "btnTotalContractedVolume";
            this.btnTotalContractedVolume.Size = new System.Drawing.Size(246, 23);
            this.btnTotalContractedVolume.TabIndex = 1;
            this.btnTotalContractedVolume.Text = "Total contracted volume";
            this.btnTotalContractedVolume.UseVisualStyleBackColor = true;
            this.btnTotalContractedVolume.Click += new System.EventHandler(this.btnTotalContractedVolume_Click);
            // 
            // txtContractId
            // 
            this.txtContractId.Location = new System.Drawing.Point(103, 55);
            this.txtContractId.Name = "txtContractId";
            this.txtContractId.ReadOnly = true;
            this.txtContractId.Size = new System.Drawing.Size(246, 20);
            this.txtContractId.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Client Id";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Enabled = false;
            this.dtpStartDate.Location = new System.Drawing.Point(104, 132);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(245, 20);
            this.dtpStartDate.TabIndex = 4;
            // 
            // txtClientId
            // 
            this.txtClientId.Location = new System.Drawing.Point(103, 94);
            this.txtClientId.Name = "txtClientId";
            this.txtClientId.ReadOnly = true;
            this.txtClientId.Size = new System.Drawing.Size(246, 20);
            this.txtClientId.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Contract Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "End Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Location = new System.Drawing.Point(103, 171);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(245, 20);
            this.dtpEndDate.TabIndex = 8;
            // 
            // frmContracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 463);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClientId);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContractId);
            this.Controls.Add(this.btnTotalContractedVolume);
            this.Controls.Add(this.gridViewContracts);
            this.Name = "frmContracts";
            this.Text = "Contracts";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewContracts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridViewContracts;
        private System.Windows.Forms.Button btnTotalContractedVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDate;
        private System.Windows.Forms.TextBox txtContractId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtClientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
    }
}

