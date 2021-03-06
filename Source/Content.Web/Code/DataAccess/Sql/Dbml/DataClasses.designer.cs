﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ContentNamespace.Web.Code.DataAccess.Sql.Dbml
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="Database")]
	public partial class DataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertApplication_UserProfile(Application_UserProfile instance);
    partial void UpdateApplication_UserProfile(Application_UserProfile instance);
    partial void DeleteApplication_UserProfile(Application_UserProfile instance);
    partial void InsertUserProfile(UserProfile instance);
    partial void UpdateUserProfile(UserProfile instance);
    partial void DeleteUserProfile(UserProfile instance);
    partial void InsertHtmlContent(HtmlContent instance);
    partial void UpdateHtmlContent(HtmlContent instance);
    partial void DeleteHtmlContent(HtmlContent instance);
    partial void InsertSetting(Setting instance);
    partial void UpdateSetting(Setting instance);
    partial void DeleteSetting(Setting instance);
    partial void InsertApplication(Application instance);
    partial void UpdateApplication(Application instance);
    partial void DeleteApplication(Application instance);
    #endregion
		
		public DataClassesDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Application_UserProfile> Application_UserProfiles
		{
			get
			{
				return this.GetTable<Application_UserProfile>();
			}
		}
		
		public System.Data.Linq.Table<UserProfile> UserProfiles
		{
			get
			{
				return this.GetTable<UserProfile>();
			}
		}
		
		public System.Data.Linq.Table<HtmlContent> HtmlContents
		{
			get
			{
				return this.GetTable<HtmlContent>();
			}
		}
		
		public System.Data.Linq.Table<Setting> Settings
		{
			get
			{
				return this.GetTable<Setting>();
			}
		}
		
		public System.Data.Linq.Table<Application> Applications
		{
			get
			{
				return this.GetTable<Application>();
			}
		}
	}
	
	[Table(Name="dbo.Application_UserProfile")]
	public partial class Application_UserProfile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _ApplicationId;
		
		private int _UserProfileId;
		
		private EntityRef<UserProfile> _UserProfile;
		
		private EntityRef<Application> _Application;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnApplicationIdChanging(int value);
    partial void OnApplicationIdChanged();
    partial void OnUserProfileIdChanging(int value);
    partial void OnUserProfileIdChanged();
    #endregion
		
		public Application_UserProfile()
		{
			this._UserProfile = default(EntityRef<UserProfile>);
			this._Application = default(EntityRef<Application>);
			OnCreated();
		}
		
		[Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_ApplicationId", DbType="Int NOT NULL")]
		public int ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					if (this._Application.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[Column(Storage="_UserProfileId", DbType="Int NOT NULL")]
		public int UserProfileId
		{
			get
			{
				return this._UserProfileId;
			}
			set
			{
				if ((this._UserProfileId != value))
				{
					if (this._UserProfile.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserProfileIdChanging(value);
					this.SendPropertyChanging();
					this._UserProfileId = value;
					this.SendPropertyChanged("UserProfileId");
					this.OnUserProfileIdChanged();
				}
			}
		}
		
		[Association(Name="UserProfile_Application_UserProfile", Storage="_UserProfile", ThisKey="UserProfileId", OtherKey="Id", IsForeignKey=true)]
		public UserProfile UserProfile
		{
			get
			{
				return this._UserProfile.Entity;
			}
			set
			{
				UserProfile previousValue = this._UserProfile.Entity;
				if (((previousValue != value) 
							|| (this._UserProfile.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._UserProfile.Entity = null;
						previousValue.Application_UserProfiles.Remove(this);
					}
					this._UserProfile.Entity = value;
					if ((value != null))
					{
						value.Application_UserProfiles.Add(this);
						this._UserProfileId = value.Id;
					}
					else
					{
						this._UserProfileId = default(int);
					}
					this.SendPropertyChanged("UserProfile");
				}
			}
		}
		
		[Association(Name="Application_Application_UserProfile", Storage="_Application", ThisKey="ApplicationId", OtherKey="Id", IsForeignKey=true)]
		public Application Application
		{
			get
			{
				return this._Application.Entity;
			}
			set
			{
				Application previousValue = this._Application.Entity;
				if (((previousValue != value) 
							|| (this._Application.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Application.Entity = null;
						previousValue.Application_UserProfiles.Remove(this);
					}
					this._Application.Entity = value;
					if ((value != null))
					{
						value.Application_UserProfiles.Add(this);
						this._ApplicationId = value.Id;
					}
					else
					{
						this._ApplicationId = default(int);
					}
					this.SendPropertyChanged("Application");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.UserProfile")]
	public partial class UserProfile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _UserName;
		
		private string _Email;
		
		private string _OpenIdId;
		
		private System.Nullable<System.DateTime> _LastSignInDate;
		
		private System.Nullable<System.DateTime> _RegisterDate;
		
		private System.Nullable<System.DateTime> _CreatedDate;
		
		private System.Nullable<System.DateTime> _ModifiedDate;
		
		private string _CreatedBy;
		
		private string _ModifiedBy;
		
		private EntitySet<Application_UserProfile> _Application_UserProfiles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnOpenIdIdChanging(string value);
    partial void OnOpenIdIdChanged();
    partial void OnLastSignInDateChanging(System.Nullable<System.DateTime> value);
    partial void OnLastSignInDateChanged();
    partial void OnRegisterDateChanging(System.Nullable<System.DateTime> value);
    partial void OnRegisterDateChanged();
    partial void OnCreatedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedDateChanged();
    partial void OnModifiedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnModifiedDateChanged();
    partial void OnCreatedByChanging(string value);
    partial void OnCreatedByChanged();
    partial void OnModifiedByChanging(string value);
    partial void OnModifiedByChanged();
    #endregion
		
		public UserProfile()
		{
			this._Application_UserProfiles = new EntitySet<Application_UserProfile>(new Action<Application_UserProfile>(this.attach_Application_UserProfiles), new Action<Application_UserProfile>(this.detach_Application_UserProfiles));
			OnCreated();
		}
		
		[Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(250)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_UserName", DbType="NVarChar(50)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[Column(Storage="_Email", DbType="NVarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[Column(Storage="_OpenIdId", DbType="NVarChar(MAX)")]
		public string OpenIdId
		{
			get
			{
				return this._OpenIdId;
			}
			set
			{
				if ((this._OpenIdId != value))
				{
					this.OnOpenIdIdChanging(value);
					this.SendPropertyChanging();
					this._OpenIdId = value;
					this.SendPropertyChanged("OpenIdId");
					this.OnOpenIdIdChanged();
				}
			}
		}
		
		[Column(Storage="_LastSignInDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastSignInDate
		{
			get
			{
				return this._LastSignInDate;
			}
			set
			{
				if ((this._LastSignInDate != value))
				{
					this.OnLastSignInDateChanging(value);
					this.SendPropertyChanging();
					this._LastSignInDate = value;
					this.SendPropertyChanged("LastSignInDate");
					this.OnLastSignInDateChanged();
				}
			}
		}
		
		[Column(Storage="_RegisterDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> RegisterDate
		{
			get
			{
				return this._RegisterDate;
			}
			set
			{
				if ((this._RegisterDate != value))
				{
					this.OnRegisterDateChanging(value);
					this.SendPropertyChanging();
					this._RegisterDate = value;
					this.SendPropertyChanged("RegisterDate");
					this.OnRegisterDateChanged();
				}
			}
		}
		
		[Column(Storage="_CreatedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[Column(Storage="_ModifiedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[Column(Storage="_CreatedBy", DbType="NVarChar(50)")]
		public string CreatedBy
		{
			get
			{
				return this._CreatedBy;
			}
			set
			{
				if ((this._CreatedBy != value))
				{
					this.OnCreatedByChanging(value);
					this.SendPropertyChanging();
					this._CreatedBy = value;
					this.SendPropertyChanged("CreatedBy");
					this.OnCreatedByChanged();
				}
			}
		}
		
		[Column(Storage="_ModifiedBy", DbType="NVarChar(50)")]
		public string ModifiedBy
		{
			get
			{
				return this._ModifiedBy;
			}
			set
			{
				if ((this._ModifiedBy != value))
				{
					this.OnModifiedByChanging(value);
					this.SendPropertyChanging();
					this._ModifiedBy = value;
					this.SendPropertyChanged("ModifiedBy");
					this.OnModifiedByChanged();
				}
			}
		}
		
		[Association(Name="UserProfile_Application_UserProfile", Storage="_Application_UserProfiles", ThisKey="Id", OtherKey="UserProfileId")]
		public EntitySet<Application_UserProfile> Application_UserProfiles
		{
			get
			{
				return this._Application_UserProfiles;
			}
			set
			{
				this._Application_UserProfiles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Application_UserProfiles(Application_UserProfile entity)
		{
			this.SendPropertyChanging();
			entity.UserProfile = this;
		}
		
		private void detach_Application_UserProfiles(Application_UserProfile entity)
		{
			this.SendPropertyChanging();
			entity.UserProfile = null;
		}
	}
	
	[Table(Name="dbo.HtmlContent")]
	public partial class HtmlContent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _ContentData;
		
		private System.Nullable<System.DateTime> _ExpireDate;
		
		private System.Nullable<System.DateTime> _ActiveDate;
		
		private System.Nullable<System.DateTime> _CreatedDate;
		
		private string _CreatedBy;
		
		private System.Nullable<System.DateTime> _ModifiedDate;
		
		private string _ModifiedBy;
		
		private System.Nullable<int> _ApplicationId;
		
		private System.Nullable<int> _ItemState;
		
		private EntityRef<Application> _Application;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnContentDataChanging(string value);
    partial void OnContentDataChanged();
    partial void OnExpireDateChanging(System.Nullable<System.DateTime> value);
    partial void OnExpireDateChanged();
    partial void OnActiveDateChanging(System.Nullable<System.DateTime> value);
    partial void OnActiveDateChanged();
    partial void OnCreatedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedDateChanged();
    partial void OnCreatedByChanging(string value);
    partial void OnCreatedByChanged();
    partial void OnModifiedDateChanging(System.Nullable<System.DateTime> value);
    partial void OnModifiedDateChanged();
    partial void OnModifiedByChanging(string value);
    partial void OnModifiedByChanged();
    partial void OnApplicationIdChanging(System.Nullable<int> value);
    partial void OnApplicationIdChanged();
    partial void OnItemStateChanging(System.Nullable<int> value);
    partial void OnItemStateChanged();
    #endregion
		
		public HtmlContent()
		{
			this._Application = default(EntityRef<Application>);
			OnCreated();
		}
		
		[Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NChar(250)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_ContentData", DbType="NVarChar(MAX)")]
		public string ContentData
		{
			get
			{
				return this._ContentData;
			}
			set
			{
				if ((this._ContentData != value))
				{
					this.OnContentDataChanging(value);
					this.SendPropertyChanging();
					this._ContentData = value;
					this.SendPropertyChanged("ContentData");
					this.OnContentDataChanged();
				}
			}
		}
		
		[Column(Storage="_ExpireDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ExpireDate
		{
			get
			{
				return this._ExpireDate;
			}
			set
			{
				if ((this._ExpireDate != value))
				{
					this.OnExpireDateChanging(value);
					this.SendPropertyChanging();
					this._ExpireDate = value;
					this.SendPropertyChanged("ExpireDate");
					this.OnExpireDateChanged();
				}
			}
		}
		
		[Column(Storage="_ActiveDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ActiveDate
		{
			get
			{
				return this._ActiveDate;
			}
			set
			{
				if ((this._ActiveDate != value))
				{
					this.OnActiveDateChanging(value);
					this.SendPropertyChanging();
					this._ActiveDate = value;
					this.SendPropertyChanged("ActiveDate");
					this.OnActiveDateChanged();
				}
			}
		}
		
		[Column(Storage="_CreatedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> CreatedDate
		{
			get
			{
				return this._CreatedDate;
			}
			set
			{
				if ((this._CreatedDate != value))
				{
					this.OnCreatedDateChanging(value);
					this.SendPropertyChanging();
					this._CreatedDate = value;
					this.SendPropertyChanged("CreatedDate");
					this.OnCreatedDateChanged();
				}
			}
		}
		
		[Column(Storage="_CreatedBy", DbType="NVarChar(50)")]
		public string CreatedBy
		{
			get
			{
				return this._CreatedBy;
			}
			set
			{
				if ((this._CreatedBy != value))
				{
					this.OnCreatedByChanging(value);
					this.SendPropertyChanging();
					this._CreatedBy = value;
					this.SendPropertyChanged("CreatedBy");
					this.OnCreatedByChanged();
				}
			}
		}
		
		[Column(Storage="_ModifiedDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[Column(Storage="_ModifiedBy", DbType="NVarChar(50)")]
		public string ModifiedBy
		{
			get
			{
				return this._ModifiedBy;
			}
			set
			{
				if ((this._ModifiedBy != value))
				{
					this.OnModifiedByChanging(value);
					this.SendPropertyChanging();
					this._ModifiedBy = value;
					this.SendPropertyChanged("ModifiedBy");
					this.OnModifiedByChanged();
				}
			}
		}
		
		[Column(Storage="_ApplicationId", DbType="Int")]
		public System.Nullable<int> ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					if (this._Application.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[Column(Storage="_ItemState", DbType="Int")]
		public System.Nullable<int> ItemState
		{
			get
			{
				return this._ItemState;
			}
			set
			{
				if ((this._ItemState != value))
				{
					this.OnItemStateChanging(value);
					this.SendPropertyChanging();
					this._ItemState = value;
					this.SendPropertyChanged("ItemState");
					this.OnItemStateChanged();
				}
			}
		}
		
		[Association(Name="Application_HtmlContent", Storage="_Application", ThisKey="ApplicationId", OtherKey="Id", IsForeignKey=true)]
		public Application Application
		{
			get
			{
				return this._Application.Entity;
			}
			set
			{
				Application previousValue = this._Application.Entity;
				if (((previousValue != value) 
							|| (this._Application.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Application.Entity = null;
						previousValue.HtmlContents.Remove(this);
					}
					this._Application.Entity = value;
					if ((value != null))
					{
						value.HtmlContents.Add(this);
						this._ApplicationId = value.Id;
					}
					else
					{
						this._ApplicationId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Application");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Setting")]
	public partial class Setting : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _ApplicationId;
		
		private string _Type;
		
		private string _Data;
		
		private System.DateTime _ModifiedDate;
		
		private string _ModifiedBy;
		
		private EntityRef<Application> _Application;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnApplicationIdChanging(int value);
    partial void OnApplicationIdChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    partial void OnDataChanging(string value);
    partial void OnDataChanged();
    partial void OnModifiedDateChanging(System.DateTime value);
    partial void OnModifiedDateChanged();
    partial void OnModifiedByChanging(string value);
    partial void OnModifiedByChanged();
    #endregion
		
		public Setting()
		{
			this._Application = default(EntityRef<Application>);
			OnCreated();
		}
		
		[Column(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_ApplicationId", DbType="Int NOT NULL")]
		public int ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					if (this._Application.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[Column(Storage="_Data", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[Column(Storage="_ModifiedDate", DbType="DateTime NOT NULL")]
		public System.DateTime ModifiedDate
		{
			get
			{
				return this._ModifiedDate;
			}
			set
			{
				if ((this._ModifiedDate != value))
				{
					this.OnModifiedDateChanging(value);
					this.SendPropertyChanging();
					this._ModifiedDate = value;
					this.SendPropertyChanged("ModifiedDate");
					this.OnModifiedDateChanged();
				}
			}
		}
		
		[Column(Storage="_ModifiedBy", DbType="NVarChar(64) NOT NULL", CanBeNull=false)]
		public string ModifiedBy
		{
			get
			{
				return this._ModifiedBy;
			}
			set
			{
				if ((this._ModifiedBy != value))
				{
					this.OnModifiedByChanging(value);
					this.SendPropertyChanging();
					this._ModifiedBy = value;
					this.SendPropertyChanged("ModifiedBy");
					this.OnModifiedByChanged();
				}
			}
		}
		
		[Association(Name="Application_Setting", Storage="_Application", ThisKey="ApplicationId", OtherKey="Id", IsForeignKey=true)]
		public Application Application
		{
			get
			{
				return this._Application.Entity;
			}
			set
			{
				Application previousValue = this._Application.Entity;
				if (((previousValue != value) 
							|| (this._Application.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Application.Entity = null;
						previousValue.Settings.Remove(this);
					}
					this._Application.Entity = value;
					if ((value != null))
					{
						value.Settings.Add(this);
						this._ApplicationId = value.Id;
					}
					else
					{
						this._ApplicationId = default(int);
					}
					this.SendPropertyChanged("Application");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Application")]
	public partial class Application : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private EntitySet<Application_UserProfile> _Application_UserProfiles;
		
		private EntitySet<HtmlContent> _HtmlContents;
		
		private EntitySet<Setting> _Settings;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Application()
		{
			this._Application_UserProfiles = new EntitySet<Application_UserProfile>(new Action<Application_UserProfile>(this.attach_Application_UserProfiles), new Action<Application_UserProfile>(this.detach_Application_UserProfiles));
			this._HtmlContents = new EntitySet<HtmlContent>(new Action<HtmlContent>(this.attach_HtmlContents), new Action<HtmlContent>(this.detach_HtmlContents));
			this._Settings = new EntitySet<Setting>(new Action<Setting>(this.attach_Settings), new Action<Setting>(this.detach_Settings));
			OnCreated();
		}
		
		[Column(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Association(Name="Application_Application_UserProfile", Storage="_Application_UserProfiles", ThisKey="Id", OtherKey="ApplicationId")]
		public EntitySet<Application_UserProfile> Application_UserProfiles
		{
			get
			{
				return this._Application_UserProfiles;
			}
			set
			{
				this._Application_UserProfiles.Assign(value);
			}
		}
		
		[Association(Name="Application_HtmlContent", Storage="_HtmlContents", ThisKey="Id", OtherKey="ApplicationId")]
		public EntitySet<HtmlContent> HtmlContents
		{
			get
			{
				return this._HtmlContents;
			}
			set
			{
				this._HtmlContents.Assign(value);
			}
		}
		
		[Association(Name="Application_Setting", Storage="_Settings", ThisKey="Id", OtherKey="ApplicationId")]
		public EntitySet<Setting> Settings
		{
			get
			{
				return this._Settings;
			}
			set
			{
				this._Settings.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Application_UserProfiles(Application_UserProfile entity)
		{
			this.SendPropertyChanging();
			entity.Application = this;
		}
		
		private void detach_Application_UserProfiles(Application_UserProfile entity)
		{
			this.SendPropertyChanging();
			entity.Application = null;
		}
		
		private void attach_HtmlContents(HtmlContent entity)
		{
			this.SendPropertyChanging();
			entity.Application = this;
		}
		
		private void detach_HtmlContents(HtmlContent entity)
		{
			this.SendPropertyChanging();
			entity.Application = null;
		}
		
		private void attach_Settings(Setting entity)
		{
			this.SendPropertyChanging();
			entity.Application = this;
		}
		
		private void detach_Settings(Setting entity)
		{
			this.SendPropertyChanging();
			entity.Application = null;
		}
	}
}
#pragma warning restore 1591
