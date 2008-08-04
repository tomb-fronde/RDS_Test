namespace NZPostOffice.RDS.DataControls.Ruraldw
{
    partial class DUserGroupTest
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
            this.n_37935089 = new System.Windows.Forms.Label();
            this.gp_created_date = new System.Windows.Forms.TextBox();
            this.gp_created_by = new System.Windows.Forms.TextBox();
            this.gp_modified_date = new System.Windows.Forms.TextBox();
            this.gp_modified_by = new System.Windows.Forms.TextBox();
            this.gp_title_t = new System.Windows.Forms.Label();
            this.gp_created_date_t = new System.Windows.Forms.Label();
            this.gp_created_by_t = new System.Windows.Forms.Label();
            this.gp_modified_date_t = new System.Windows.Forms.Label();
            this.gp_modified_by_t = new System.Windows.Forms.Label();
            this.gp_level_1_t = new System.Windows.Forms.Label();
            this.gp_level_2_t = new System.Windows.Forms.Label();
            this.n_5871486 = new System.Windows.Forms.Label();
            this.n_52843375 = new System.Windows.Forms.Label();
            this.n_5828335 = new System.Windows.Forms.Label();
            this.n_52455022 = new System.Windows.Forms.Label();
            this.n_2333158 = new System.Windows.Forms.Label();
            this.n_20998422 = new System.Windows.Forms.Label();
            this.n_54768072 = new System.Windows.Forms.Label();
            this.n_23150606 = new System.Windows.Forms.Label();
            this.n_7028863 = new System.Windows.Forms.Label();
            this.n_63259774 = new System.Windows.Forms.Label();
            this.n_32467059 = new System.Windows.Forms.Label();
            this.n_23768079 = new System.Windows.Forms.Label();
            this.n_12586123 = new System.Windows.Forms.Label();
            this.n_46166248 = new System.Windows.Forms.Label();
            this.n_12843056 = new System.Windows.Forms.TextBox();
            this.n_48478642 = new System.Windows.Forms.TextBox();
            this.n_33654601 = new System.Windows.Forms.TextBox();
            this.n_34455957 = new System.Windows.Forms.TextBox();
            this.n_41668159 = new System.Windows.Forms.TextBox();
            this.n_39469112 = new System.Windows.Forms.TextBox();
            this.n_19677689 = new System.Windows.Forms.TextBox();
            this.n_42881475 = new System.Windows.Forms.TextBox();
            this.gp_title = new System.Windows.Forms.TextBox();
            this.gp_code = new System.Windows.Forms.TextBox();
            this.gp_level_7 = new Metex.Windows.DataEntityCombo();
            this.gp_level_3 = new Metex.Windows.DataEntityCombo();
            this.gp_level_4 = new Metex.Windows.DataEntityCombo();
            this.gp_level_5 = new Metex.Windows.DataEntityCombo();
            this.gp_level_1 = new Metex.Windows.DataEntityCombo();
            this.gp_level_2 = new Metex.Windows.DataEntityCombo();
            this.gp_level_9 = new Metex.Windows.DataEntityCombo();
            this.gp_level_6 = new Metex.Windows.DataEntityCombo();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(NZPostOffice.RDS.Entity.Ruraldw.UserGroupTest);
            // 
            // n_37935089
            // 
            this.n_37935089.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_37935089.Location = new System.Drawing.Point(120, 5);
            this.n_37935089.Name = "n_37935089";
            this.n_37935089.Size = new System.Drawing.Size(92, 13);
            this.n_37935089.TabIndex = 0;
            this.n_37935089.Text = "User Groups";
            this.n_37935089.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gp_created_date
            // 
            this.gp_created_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpCreatedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_created_date.Enabled = false;
            this.gp_created_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_created_date.Location = new System.Drawing.Point(115, 32);
            this.gp_created_date.Name = "gp_created_date";
            this.gp_created_date.Size = new System.Drawing.Size(68, 20);
            this.gp_created_date.TabIndex = 0;
            // 
            // gp_created_by
            // 
            this.gp_created_by.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpCreatedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_created_by.Enabled = false;
            this.gp_created_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_created_by.Location = new System.Drawing.Point(115, 56);
            this.gp_created_by.MaxLength = 20;
            this.gp_created_by.Name = "gp_created_by";
            this.gp_created_by.Size = new System.Drawing.Size(120, 20);
            this.gp_created_by.TabIndex = 0;
            // 
            // gp_modified_date
            // 
            this.gp_modified_date.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpModifiedDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_modified_date.Enabled = false;
            this.gp_modified_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_modified_date.Location = new System.Drawing.Point(115, 80);
            this.gp_modified_date.Name = "gp_modified_date";
            this.gp_modified_date.Size = new System.Drawing.Size(68, 20);
            this.gp_modified_date.TabIndex = 0;
            // 
            // gp_modified_by
            // 
            this.gp_modified_by.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpModifiedBy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_modified_by.Enabled = false;
            this.gp_modified_by.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_modified_by.Location = new System.Drawing.Point(115, 104);
            this.gp_modified_by.MaxLength = 20;
            this.gp_modified_by.Name = "gp_modified_by";
            this.gp_modified_by.Size = new System.Drawing.Size(120, 20);
            this.gp_modified_by.TabIndex = 0;
            // 
            // gp_title_t
            // 
            this.gp_title_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_title_t.Location = new System.Drawing.Point(49, 4);
            this.gp_title_t.Name = "gp_title_t";
            this.gp_title_t.Size = new System.Drawing.Size(59, 13);
            this.gp_title_t.TabIndex = 0;
            this.gp_title_t.Text = "Group Title";
            this.gp_title_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gp_created_date_t
            // 
            this.gp_created_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_created_date_t.Location = new System.Drawing.Point(36, 32);
            this.gp_created_date_t.Name = "gp_created_date_t";
            this.gp_created_date_t.Size = new System.Drawing.Size(72, 13);
            this.gp_created_date_t.TabIndex = 0;
            this.gp_created_date_t.Text = "Created Date";
            this.gp_created_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gp_created_by_t
            // 
            this.gp_created_by_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_created_by_t.Location = new System.Drawing.Point(49, 56);
            this.gp_created_by_t.Name = "gp_created_by_t";
            this.gp_created_by_t.Size = new System.Drawing.Size(59, 13);
            this.gp_created_by_t.TabIndex = 0;
            this.gp_created_by_t.Text = "Created By";
            this.gp_created_by_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gp_modified_date_t
            // 
            this.gp_modified_date_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_modified_date_t.Location = new System.Drawing.Point(33, 80);
            this.gp_modified_date_t.Name = "gp_modified_date_t";
            this.gp_modified_date_t.Size = new System.Drawing.Size(75, 13);
            this.gp_modified_date_t.TabIndex = 0;
            this.gp_modified_date_t.Text = "Modified Date";
            this.gp_modified_date_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gp_modified_by_t
            // 
            this.gp_modified_by_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_modified_by_t.Location = new System.Drawing.Point(45, 104);
            this.gp_modified_by_t.Name = "gp_modified_by_t";
            this.gp_modified_by_t.Size = new System.Drawing.Size(62, 13);
            this.gp_modified_by_t.TabIndex = 0;
            this.gp_modified_by_t.Text = "Modified By";
            this.gp_modified_by_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gp_level_1_t
            // 
            this.gp_level_1_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_1_t.Location = new System.Drawing.Point(13, 137);
            this.gp_level_1_t.Name = "gp_level_1_t";
            this.gp_level_1_t.Size = new System.Drawing.Size(97, 13);
            this.gp_level_1_t.TabIndex = 0;
            this.gp_level_1_t.Text = "Benchmark Rates";
            this.gp_level_1_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gp_level_2_t
            // 
            this.gp_level_2_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_2_t.Location = new System.Drawing.Point(31, 161);
            this.gp_level_2_t.Name = "gp_level_2_t";
            this.gp_level_2_t.Size = new System.Drawing.Size(78, 13);
            this.gp_level_2_t.TabIndex = 0;
            this.gp_level_2_t.Text = "System Tables";
            this.gp_level_2_t.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_5871486
            // 
            this.n_5871486.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_5871486.Location = new System.Drawing.Point(67, 185);
            this.n_5871486.Name = "n_5871486";
            this.n_5871486.Size = new System.Drawing.Size(43, 13);
            this.n_5871486.TabIndex = 0;
            this.n_5871486.Text = "Security";
            this.n_5871486.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_52843375
            // 
            this.n_52843375.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_52843375.Location = new System.Drawing.Point(18, 209);
            this.n_52843375.Name = "n_52843375";
            this.n_52843375.Size = new System.Drawing.Size(93, 13);
            this.n_52843375.TabIndex = 0;
            this.n_52843375.Text = "Regional Reports";
            this.n_52843375.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_5828335
            // 
            this.n_5828335.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_5828335.Location = new System.Drawing.Point(295, 138);
            this.n_5828335.Name = "n_5828335";
            this.n_5828335.Size = new System.Drawing.Size(61, 13);
            this.n_5828335.TabIndex = 0;
            this.n_5828335.Text = "HQ Access";
            this.n_5828335.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_52455022
            // 
            this.n_52455022.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_52455022.Location = new System.Drawing.Point(268, 162);
            this.n_52455022.Name = "n_52455022";
            this.n_52455022.Size = new System.Drawing.Size(89, 13);
            this.n_52455022.TabIndex = 0;
            this.n_52455022.Text = "Contract Access";
            this.n_52455022.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_2333158
            // 
            this.n_2333158.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_2333158.Location = new System.Drawing.Point(262, 186);
            this.n_2333158.Name = "n_2333158";
            this.n_2333158.Size = new System.Drawing.Size(94, 13);
            this.n_2333158.TabIndex = 0;
            this.n_2333158.Text = "Owner Driver Info";
            this.n_2333158.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_20998422
            // 
            this.n_20998422.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_20998422.Location = new System.Drawing.Point(301, 210);
            this.n_20998422.Name = "n_20998422";
            this.n_20998422.Size = new System.Drawing.Size(56, 13);
            this.n_20998422.TabIndex = 0;
            this.n_20998422.Text = "Customers";
            this.n_20998422.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // n_54768072
            // 
            this.n_54768072.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_54768072.Location = new System.Drawing.Point(117, 137);
            this.n_54768072.Name = "n_54768072";
            this.n_54768072.Size = new System.Drawing.Size(9, 13);
            this.n_54768072.TabIndex = 0;
            this.n_54768072.Text = "1";
            this.n_54768072.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_23150606
            // 
            this.n_23150606.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_23150606.Location = new System.Drawing.Point(117, 163);
            this.n_23150606.Name = "n_23150606";
            this.n_23150606.Size = new System.Drawing.Size(9, 13);
            this.n_23150606.TabIndex = 0;
            this.n_23150606.Text = "2";
            this.n_23150606.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_7028863
            // 
            this.n_7028863.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_7028863.Location = new System.Drawing.Point(117, 187);
            this.n_7028863.Name = "n_7028863";
            this.n_7028863.Size = new System.Drawing.Size(9, 13);
            this.n_7028863.TabIndex = 0;
            this.n_7028863.Text = "9";
            this.n_7028863.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_63259774
            // 
            this.n_63259774.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_63259774.Location = new System.Drawing.Point(117, 209);
            this.n_63259774.Name = "n_63259774";
            this.n_63259774.Size = new System.Drawing.Size(9, 13);
            this.n_63259774.TabIndex = 0;
            this.n_63259774.Text = "6";
            this.n_63259774.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_32467059
            // 
            this.n_32467059.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_32467059.Location = new System.Drawing.Point(370, 137);
            this.n_32467059.Name = "n_32467059";
            this.n_32467059.Size = new System.Drawing.Size(9, 13);
            this.n_32467059.TabIndex = 0;
            this.n_32467059.Text = "7";
            this.n_32467059.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_23768079
            // 
            this.n_23768079.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_23768079.Location = new System.Drawing.Point(370, 161);
            this.n_23768079.Name = "n_23768079";
            this.n_23768079.Size = new System.Drawing.Size(9, 13);
            this.n_23768079.TabIndex = 0;
            this.n_23768079.Text = "3";
            this.n_23768079.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_12586123
            // 
            this.n_12586123.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_12586123.Location = new System.Drawing.Point(370, 186);
            this.n_12586123.Name = "n_12586123";
            this.n_12586123.Size = new System.Drawing.Size(9, 13);
            this.n_12586123.TabIndex = 0;
            this.n_12586123.Text = "4";
            this.n_12586123.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_46166248
            // 
            this.n_46166248.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_46166248.Location = new System.Drawing.Point(371, 209);
            this.n_46166248.Name = "n_46166248";
            this.n_46166248.Size = new System.Drawing.Size(9, 13);
            this.n_46166248.TabIndex = 0;
            this.n_46166248.Text = "5";
            this.n_46166248.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // n_12843056
            // 
            this.n_12843056.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpLevel7", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.n_12843056.Enabled = false;
            this.n_12843056.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_12843056.Location = new System.Drawing.Point(538, 134);
            this.n_12843056.Name = "n_12843056";
            this.n_12843056.Size = new System.Drawing.Size(16, 20);
            this.n_12843056.TabIndex = 0;
            // 
            // n_48478642
            // 
            this.n_48478642.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpLevel3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.n_48478642.Enabled = false;
            this.n_48478642.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_48478642.Location = new System.Drawing.Point(538, 158);
            this.n_48478642.Name = "n_48478642";
            this.n_48478642.Size = new System.Drawing.Size(16, 20);
            this.n_48478642.TabIndex = 0;
            // 
            // n_33654601
            // 
            this.n_33654601.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpLevel4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.n_33654601.Enabled = false;
            this.n_33654601.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_33654601.Location = new System.Drawing.Point(538, 184);
            this.n_33654601.Name = "n_33654601";
            this.n_33654601.Size = new System.Drawing.Size(16, 20);
            this.n_33654601.TabIndex = 0;
            // 
            // n_34455957
            // 
            this.n_34455957.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpLevel5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.n_34455957.Enabled = false;
            this.n_34455957.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_34455957.Location = new System.Drawing.Point(538, 206);
            this.n_34455957.Name = "n_34455957";
            this.n_34455957.Size = new System.Drawing.Size(16, 20);
            this.n_34455957.TabIndex = 0;
            // 
            // n_41668159
            // 
            this.n_41668159.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpLevel1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.n_41668159.Enabled = false;
            this.n_41668159.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_41668159.Location = new System.Drawing.Point(234, 134);
            this.n_41668159.Name = "n_41668159";
            this.n_41668159.Size = new System.Drawing.Size(16, 20);
            this.n_41668159.TabIndex = 0;
            // 
            // n_39469112
            // 
            this.n_39469112.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpLevel2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.n_39469112.Enabled = false;
            this.n_39469112.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_39469112.Location = new System.Drawing.Point(234, 158);
            this.n_39469112.Name = "n_39469112";
            this.n_39469112.Size = new System.Drawing.Size(16, 20);
            this.n_39469112.TabIndex = 0;
            // 
            // n_19677689
            // 
            this.n_19677689.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpLevel9", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.n_19677689.Enabled = false;
            this.n_19677689.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_19677689.Location = new System.Drawing.Point(234, 184);
            this.n_19677689.Name = "n_19677689";
            this.n_19677689.Size = new System.Drawing.Size(16, 20);
            this.n_19677689.TabIndex = 0;
            // 
            // n_42881475
            // 
            this.n_42881475.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpLevel6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.n_42881475.Enabled = false;
            this.n_42881475.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.n_42881475.Location = new System.Drawing.Point(234, 206);
            this.n_42881475.Name = "n_42881475";
            this.n_42881475.Size = new System.Drawing.Size(16, 20);
            this.n_42881475.TabIndex = 0;
            // 
            // gp_title
            // 
            this.gp_title.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_title.Location = new System.Drawing.Point(115, 2);
            this.gp_title.MaxLength = 40;
            this.gp_title.Name = "gp_title";
            this.gp_title.Size = new System.Drawing.Size(234, 20);
            this.gp_title.TabIndex = 10;
            // 
            // gp_code
            // 
            this.gp_code.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "GpCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_code.Enabled = false;
            this.gp_code.Font = new System.Drawing.Font("Arial", 8F);
            this.gp_code.Location = new System.Drawing.Point(361, 1);
            this.gp_code.Name = "gp_code";
            this.gp_code.Size = new System.Drawing.Size(91, 20);
            this.gp_code.TabIndex = 0;
            // 
            // gp_level_7
            // 
            this.gp_level_7.AutoRetrieve = false;
            this.gp_level_7.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "GpLevel7", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_level_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_7.Location = new System.Drawing.Point(388, 134);
            this.gp_level_7.Name = "gp_level_7";
            this.gp_level_7.Size = new System.Drawing.Size(144, 21);
            this.gp_level_7.TabIndex = 60;
            this.gp_level_7.Value = null;
            // 
            // gp_level_3
            // 
            this.gp_level_3.AutoRetrieve = false;
            this.gp_level_3.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "GpLevel3", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_level_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_3.Location = new System.Drawing.Point(388, 158);
            this.gp_level_3.Name = "gp_level_3";
            this.gp_level_3.Size = new System.Drawing.Size(144, 21);
            this.gp_level_3.TabIndex = 70;
            this.gp_level_3.Value = null;
            // 
            // gp_level_4
            // 
            this.gp_level_4.AutoRetrieve = false;
            this.gp_level_4.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "GpLevel4", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_level_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_4.Location = new System.Drawing.Point(388, 182);
            this.gp_level_4.Name = "gp_level_4";
            this.gp_level_4.Size = new System.Drawing.Size(144, 21);
            this.gp_level_4.TabIndex = 80;
            this.gp_level_4.Value = null;
            // 
            // gp_level_5
            // 
            this.gp_level_5.AutoRetrieve = false;
            this.gp_level_5.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "GpLevel5", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_level_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_5.Location = new System.Drawing.Point(388, 206);
            this.gp_level_5.Name = "gp_level_5";
            this.gp_level_5.Size = new System.Drawing.Size(144, 21);
            this.gp_level_5.TabIndex = 90;
            this.gp_level_5.Value = null;
            // 
            // gp_level_1
            // 
            this.gp_level_1.AutoRetrieve = false;
            this.gp_level_1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "GpLevel1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_level_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_1.Location = new System.Drawing.Point(136, 134);
            this.gp_level_1.Name = "gp_level_1";
            this.gp_level_1.Size = new System.Drawing.Size(92, 21);
            this.gp_level_1.TabIndex = 20;
            this.gp_level_1.Value = null;
            // 
            // gp_level_2
            // 
            this.gp_level_2.AutoRetrieve = false;
            this.gp_level_2.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "GpLevel2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_level_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_2.Location = new System.Drawing.Point(136, 158);
            this.gp_level_2.Name = "gp_level_2";
            this.gp_level_2.Size = new System.Drawing.Size(92, 21);
            this.gp_level_2.TabIndex = 30;
            this.gp_level_2.Value = null;
            // 
            // gp_level_9
            // 
            this.gp_level_9.AutoRetrieve = false;
            this.gp_level_9.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "GpLevel9", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_level_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_9.Location = new System.Drawing.Point(136, 182);
            this.gp_level_9.Name = "gp_level_9";
            this.gp_level_9.Size = new System.Drawing.Size(91, 21);
            this.gp_level_9.TabIndex = 40;
            this.gp_level_9.Value = null;
            // 
            // gp_level_6
            // 
            this.gp_level_6.AutoRetrieve = false;
            this.gp_level_6.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "GpLevel6", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.gp_level_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gp_level_6.Location = new System.Drawing.Point(136, 206);
            this.gp_level_6.Name = "gp_level_6";
            this.gp_level_6.Size = new System.Drawing.Size(91, 21);
            this.gp_level_6.TabIndex = 50;
            this.gp_level_6.Value = null;
            // 
            // DUserGroupTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.n_37935089);
            this.Controls.Add(this.gp_created_date);
            this.Controls.Add(this.gp_created_by);
            this.Controls.Add(this.gp_modified_date);
            this.Controls.Add(this.gp_modified_by);
            this.Controls.Add(this.gp_title_t);
            this.Controls.Add(this.gp_created_date_t);
            this.Controls.Add(this.gp_created_by_t);
            this.Controls.Add(this.gp_modified_date_t);
            this.Controls.Add(this.gp_modified_by_t);
            this.Controls.Add(this.gp_level_1_t);
            this.Controls.Add(this.gp_level_2_t);
            this.Controls.Add(this.n_5871486);
            this.Controls.Add(this.n_52843375);
            this.Controls.Add(this.n_5828335);
            this.Controls.Add(this.n_52455022);
            this.Controls.Add(this.n_2333158);
            this.Controls.Add(this.n_20998422);
            this.Controls.Add(this.n_54768072);
            this.Controls.Add(this.n_23150606);
            this.Controls.Add(this.n_7028863);
            this.Controls.Add(this.n_63259774);
            this.Controls.Add(this.n_32467059);
            this.Controls.Add(this.n_23768079);
            this.Controls.Add(this.n_12586123);
            this.Controls.Add(this.n_46166248);
            this.Controls.Add(this.n_12843056);
            this.Controls.Add(this.n_48478642);
            this.Controls.Add(this.n_33654601);
            this.Controls.Add(this.n_34455957);
            this.Controls.Add(this.n_41668159);
            this.Controls.Add(this.n_39469112);
            this.Controls.Add(this.n_19677689);
            this.Controls.Add(this.n_42881475);
            this.Controls.Add(this.gp_title);
            this.Controls.Add(this.gp_code);
            this.Controls.Add(this.gp_level_7);
            this.Controls.Add(this.gp_level_3);
            this.Controls.Add(this.gp_level_4);
            this.Controls.Add(this.gp_level_5);
            this.Controls.Add(this.gp_level_1);
            this.Controls.Add(this.gp_level_2);
            this.Controls.Add(this.gp_level_9);
            this.Controls.Add(this.gp_level_6);
            this.Name = "DUserGroupTest";
            this.Size = new System.Drawing.Size(650, 300);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label n_37935089;
        private System.Windows.Forms.TextBox gp_created_date;
        private System.Windows.Forms.TextBox gp_created_by;
        private System.Windows.Forms.TextBox gp_modified_date;
        private System.Windows.Forms.TextBox gp_modified_by;
        private System.Windows.Forms.Label gp_title_t;
        private System.Windows.Forms.Label gp_created_date_t;
        private System.Windows.Forms.Label gp_created_by_t;
        private System.Windows.Forms.Label gp_modified_date_t;
        private System.Windows.Forms.Label gp_modified_by_t;
        private System.Windows.Forms.Label gp_level_1_t;
        private System.Windows.Forms.Label gp_level_2_t;
        private System.Windows.Forms.Label n_5871486;
        private System.Windows.Forms.Label n_52843375;
        private System.Windows.Forms.Label n_5828335;
        private System.Windows.Forms.Label n_52455022;
        private System.Windows.Forms.Label n_2333158;
        private System.Windows.Forms.Label n_20998422;
        private System.Windows.Forms.Label n_54768072;
        private System.Windows.Forms.Label n_23150606;
        private System.Windows.Forms.Label n_7028863;
        private System.Windows.Forms.Label n_63259774;
        private System.Windows.Forms.Label n_32467059;
        private System.Windows.Forms.Label n_23768079;
        private System.Windows.Forms.Label n_12586123;
        private System.Windows.Forms.Label n_46166248;
        private System.Windows.Forms.TextBox n_12843056;
        private System.Windows.Forms.TextBox n_48478642;
        private System.Windows.Forms.TextBox n_33654601;
        private System.Windows.Forms.TextBox n_34455957;
        private System.Windows.Forms.TextBox n_41668159;
        private System.Windows.Forms.TextBox n_39469112;
        private System.Windows.Forms.TextBox n_19677689;
        private System.Windows.Forms.TextBox n_42881475;
        private System.Windows.Forms.TextBox gp_title;
        private System.Windows.Forms.TextBox gp_code;
        private Metex.Windows.DataEntityCombo gp_level_7;
        private Metex.Windows.DataEntityCombo gp_level_3;
        private Metex.Windows.DataEntityCombo gp_level_4;
        private Metex.Windows.DataEntityCombo gp_level_5;
        private Metex.Windows.DataEntityCombo gp_level_1;
        private Metex.Windows.DataEntityCombo gp_level_2;
        private Metex.Windows.DataEntityCombo gp_level_9;
        private Metex.Windows.DataEntityCombo gp_level_6;
    }
}
