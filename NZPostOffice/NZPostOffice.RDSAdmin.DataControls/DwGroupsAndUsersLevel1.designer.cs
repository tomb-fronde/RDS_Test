using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using NZPostOffice.RDSAdmin.Entity.Security;

namespace NZPostOffice.RDSAdmin.DataControls.Security
{
	partial class DwGroupsAndUsersLevel1
	{

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
	
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null ))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private System.Windows.Forms.TextBox   parent_id1;
		private System.Windows.Forms.TextBox   label;
		private System.Windows.Forms.TextBox   selectedpictindex;
		private System.Windows.Forms.TextBox   pictindex;
		private System.Windows.Forms.TextBox   id;

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "DwGroupsAndUsersLevel1";
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
			this.SuspendLayout();
			this.bindingSource.DataSource = typeof(NZPostOffice.RDSAdmin.Entity.Security.GroupsAndUsersLevel1);
			//
			// label
			//
			label = new System.Windows.Forms.TextBox();
			this.label.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.label.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.label.ForeColor = System.Drawing.Color.Black;
			this.label.Location = new System.Drawing.Point(1, 2);
			this.label.MaxLength = 5;
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(103, 15);
			this.label.TextAlign = HorizontalAlignment.Left;
			this.label.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.label.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "Label", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.label.ReadOnly=true;
			this.Controls.Add(label);

			//
			// id
			//
			id = new System.Windows.Forms.TextBox();
			this.id.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.id.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.id.ForeColor = System.Drawing.Color.Black;
			this.id.Location = new System.Drawing.Point(112, 2);
			this.id.MaxLength = 0;
			this.id.Name = "id";
			this.id.Size = new System.Drawing.Size(72, 15);
			this.id.TextAlign = HorizontalAlignment.Right;
			this.id.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.id.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "Id", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.id.ReadOnly=true;
			this.Controls.Add(id);

			//
			// parent_id1
			//
			parent_id1 = new System.Windows.Forms.TextBox();
			this.parent_id1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.parent_id1.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.parent_id1.ForeColor = System.Drawing.Color.Black;
			this.parent_id1.Location = new System.Drawing.Point(193, 4);
			this.parent_id1.MaxLength = 0;
			this.parent_id1.Name = "parent_id1";
			this.parent_id1.Size = new System.Drawing.Size(217, 13);
			this.parent_id1.TextAlign = HorizontalAlignment.Right;
			this.parent_id1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.parent_id1.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "ParentId1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.parent_id1.ReadOnly=true;
			this.Controls.Add(parent_id1);

			//
			// pictindex
			//
			pictindex = new System.Windows.Forms.TextBox();
			this.pictindex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.pictindex.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.pictindex.ForeColor = System.Drawing.Color.Black;
			this.pictindex.Location = new System.Drawing.Point(419, 4);
			this.pictindex.MaxLength = 0;
			this.pictindex.Name = "pictindex";
			this.pictindex.Size = new System.Drawing.Size(217, 13);
			this.pictindex.TextAlign = HorizontalAlignment.Left;
			this.pictindex.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.pictindex.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "Pictindex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.pictindex.ReadOnly=true;
			this.Controls.Add(pictindex);

			//
			// selectedpictindex
			//
			selectedpictindex = new System.Windows.Forms.TextBox();
			this.selectedpictindex.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.selectedpictindex.Font = new System.Drawing.Font("MS Sans Serif", 8F);
			this.selectedpictindex.ForeColor = System.Drawing.Color.Black;
			this.selectedpictindex.Location = new System.Drawing.Point(646, 4);
			this.selectedpictindex.MaxLength = 0;
			this.selectedpictindex.Name = "selectedpictindex";
			this.selectedpictindex.Size = new System.Drawing.Size(217, 13);
			this.selectedpictindex.TextAlign = HorizontalAlignment.Left;
			this.selectedpictindex.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.selectedpictindex.DataBindings.Add(new System.Windows.Forms.Binding("Text",
				this.bindingSource, "Selectedpictindex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.selectedpictindex.ReadOnly=true;
			this.Controls.Add(selectedpictindex);

			this.Size = new System.Drawing.Size(650, 300);
			((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
			this.ResumeLayout(false);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
		}
		#endregion

	}
}
