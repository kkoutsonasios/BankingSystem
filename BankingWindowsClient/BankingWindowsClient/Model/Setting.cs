using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingWindowsClient.Model
{
    class Setting : BaseModel<BankingWebAPI2.Models.Setting>
    {
        #region Constructors
        public Setting()
        {
            Controler = "api/Settings";
            WebRequest = new Tools.WebApi<Setting, BankingWebAPI2.Models.Setting>(this);
        }

        #endregion //Constructors

        #region Members
        private Tools.WebApi<Setting, BankingWebAPI2.Models.Setting> WebRequest;
        #endregion //Members

        #region Properties

        private long _id;
        public override long Id { get { return this._id; } set { this._id = value; RaisePropertyChangedEvent("Id"); } }

        private string _settingName;
        public string SettingName { get { return this._settingName; } set { this._settingName = value; RaisePropertyChangedEvent("SettingName"); } }

        private string _settingValueStr;
        public string SettingValueStr { get { return this._settingValueStr; } set { this._settingValueStr = value; RaisePropertyChangedEvent("SettingValueStr"); } }

        private Nullable<bool> _settingValueBool;
        public Nullable<bool> SettingValueBool { get { return this._settingValueBool; } set { this._settingValueBool = value; RaisePropertyChangedEvent("SettingValueBool"); } }

        private Nullable<double> _settingValueNumber;
        public Nullable<double> SettingValueNumber { get { return this._settingValueNumber; } set { this._settingValueNumber = value; RaisePropertyChangedEvent("SettingValueNumber"); } }

        #endregion //Properties

        #region CRUD
        public async Task CreateSetting()
        {
            WebRequest.Create();
        }

        public async Task ReadSetting()
        {
            WebRequest.Read();
        }

        public async Task UpdateSetting()
        {
            WebRequest.Update();
        }

        public async Task DeleteSetting()
        {
            WebRequest.Delete();
        }
        #endregion //CRUD

        #region Convertion Methods
        public override BankingWebAPI2.Models.Setting ToWebApiModel()
        {
            return new BankingWebAPI2.Models.Setting() { Id = this.Id, SettingName = this.SettingName, SettingValueStr = this.SettingValueStr, SettingValueBool = this.SettingValueBool, SettingValueNumber = this.SettingValueNumber };
        }

        public override void FromWebApiModel(BankingWebAPI2.Models.Setting Setting)
        {
            this.Id = Setting.Id;
            this.SettingName = Setting.SettingName;
            this.SettingValueStr = Setting.SettingValueStr;
            this.SettingValueBool = Setting.SettingValueBool;
            this.SettingValueNumber = Setting.SettingValueNumber;
        }
        #endregion //Convertion Methods
    }
}
