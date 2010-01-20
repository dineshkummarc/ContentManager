﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 1/20/2010 12:23:58 PM
namespace ContentNamespace.Web.Code.DataAccess.VistaDb
{
    
    /// <summary>
    /// There are no comments for ContentManagerEntities in the schema.
    /// </summary>
    public partial class ContentManagerEntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new ContentManagerEntities object using the connection string found in the 'ContentManagerEntities' section of the application configuration file.
        /// </summary>
        public ContentManagerEntities() : 
                base("name=ContentManagerEntities", "ContentManagerEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new ContentManagerEntities object.
        /// </summary>
        public ContentManagerEntities(string connectionString) : 
                base(connectionString, "ContentManagerEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new ContentManagerEntities object.
        /// </summary>
        public ContentManagerEntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "ContentManagerEntities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for HtmlContent in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<HtmlContent> HtmlContent
        {
            get
            {
                if ((this._HtmlContent == null))
                {
                    this._HtmlContent = base.CreateQuery<HtmlContent>("[HtmlContent]");
                }
                return this._HtmlContent;
            }
        }
        private global::System.Data.Objects.ObjectQuery<HtmlContent> _HtmlContent;
        /// <summary>
        /// There are no comments for HtmlContent in the schema.
        /// </summary>
        public void AddToHtmlContent(HtmlContent htmlContent)
        {
            base.AddObject("HtmlContent", htmlContent);
        }
    }
    /// <summary>
    /// There are no comments for ContentManagerModel.HtmlContent in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// CreatedDate
    /// CreatedBy
    /// Name
    /// ActiveDate
    /// ExpireDate
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="ContentManagerModel", Name="HtmlContent")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class HtmlContent : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new HtmlContent object.
        /// </summary>
        /// <param name="id">Initial value of Id.</param>
        /// <param name="createdDate">Initial value of CreatedDate.</param>
        /// <param name="createdBy">Initial value of CreatedBy.</param>
        /// <param name="name">Initial value of Name.</param>
        /// <param name="activeDate">Initial value of ActiveDate.</param>
        /// <param name="expireDate">Initial value of ExpireDate.</param>
        public static HtmlContent CreateHtmlContent(int id, global::System.DateTime createdDate, string createdBy, string name, global::System.DateTime activeDate, global::System.DateTime expireDate)
        {
            HtmlContent htmlContent = new HtmlContent();
            htmlContent.Id = id;
            htmlContent.CreatedDate = createdDate;
            htmlContent.CreatedBy = createdBy;
            htmlContent.Name = name;
            htmlContent.ActiveDate = activeDate;
            htmlContent.ExpireDate = expireDate;
            return htmlContent;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this.ReportPropertyChanging("Id");
                this._Id = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("Id");
                this.OnIdChanged();
            }
        }
        private int _Id;
        partial void OnIdChanging(int value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property CreatedDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.DateTime CreatedDate
        {
            get
            {
                return this._CreatedDate;
            }
            set
            {
                this.OnCreatedDateChanging(value);
                this.ReportPropertyChanging("CreatedDate");
                this._CreatedDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("CreatedDate");
                this.OnCreatedDateChanged();
            }
        }
        private global::System.DateTime _CreatedDate;
        partial void OnCreatedDateChanging(global::System.DateTime value);
        partial void OnCreatedDateChanged();
        /// <summary>
        /// There are no comments for Property CreatedBy in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string CreatedBy
        {
            get
            {
                return this._CreatedBy;
            }
            set
            {
                this.OnCreatedByChanging(value);
                this.ReportPropertyChanging("CreatedBy");
                this._CreatedBy = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("CreatedBy");
                this.OnCreatedByChanged();
            }
        }
        private string _CreatedBy;
        partial void OnCreatedByChanging(string value);
        partial void OnCreatedByChanged();
        /// <summary>
        /// There are no comments for Property ModifiedDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<global::System.DateTime> ModifiedDate
        {
            get
            {
                return this._ModifiedDate;
            }
            set
            {
                this.OnModifiedDateChanging(value);
                this.ReportPropertyChanging("ModifiedDate");
                this._ModifiedDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ModifiedDate");
                this.OnModifiedDateChanged();
            }
        }
        private global::System.Nullable<global::System.DateTime> _ModifiedDate;
        partial void OnModifiedDateChanging(global::System.Nullable<global::System.DateTime> value);
        partial void OnModifiedDateChanged();
        /// <summary>
        /// There are no comments for Property ModifiedBy in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string ModifiedBy
        {
            get
            {
                return this._ModifiedBy;
            }
            set
            {
                this.OnModifiedByChanging(value);
                this.ReportPropertyChanging("ModifiedBy");
                this._ModifiedBy = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("ModifiedBy");
                this.OnModifiedByChanged();
            }
        }
        private string _ModifiedBy;
        partial void OnModifiedByChanging(string value);
        partial void OnModifiedByChanged();
        /// <summary>
        /// There are no comments for Property ItemState in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string ItemState
        {
            get
            {
                return this._ItemState;
            }
            set
            {
                this.OnItemStateChanging(value);
                this.ReportPropertyChanging("ItemState");
                this._ItemState = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("ItemState");
                this.OnItemStateChanged();
            }
        }
        private string _ItemState;
        partial void OnItemStateChanging(string value);
        partial void OnItemStateChanged();
        /// <summary>
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this.ReportPropertyChanging("Name");
                this._Name = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("Name");
                this.OnNameChanged();
            }
        }
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for Property ContentData in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string ContentData
        {
            get
            {
                return this._ContentData;
            }
            set
            {
                this.OnContentDataChanging(value);
                this.ReportPropertyChanging("ContentData");
                this._ContentData = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, true);
                this.ReportPropertyChanged("ContentData");
                this.OnContentDataChanged();
            }
        }
        private string _ContentData;
        partial void OnContentDataChanging(string value);
        partial void OnContentDataChanged();
        /// <summary>
        /// There are no comments for Property ActiveDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.DateTime ActiveDate
        {
            get
            {
                return this._ActiveDate;
            }
            set
            {
                this.OnActiveDateChanging(value);
                this.ReportPropertyChanging("ActiveDate");
                this._ActiveDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ActiveDate");
                this.OnActiveDateChanged();
            }
        }
        private global::System.DateTime _ActiveDate;
        partial void OnActiveDateChanging(global::System.DateTime value);
        partial void OnActiveDateChanged();
        /// <summary>
        /// There are no comments for Property OwnerUserId in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute()]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.Nullable<int> OwnerUserId
        {
            get
            {
                return this._OwnerUserId;
            }
            set
            {
                this.OnOwnerUserIdChanging(value);
                this.ReportPropertyChanging("OwnerUserId");
                this._OwnerUserId = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("OwnerUserId");
                this.OnOwnerUserIdChanged();
            }
        }
        private global::System.Nullable<int> _OwnerUserId;
        partial void OnOwnerUserIdChanging(global::System.Nullable<int> value);
        partial void OnOwnerUserIdChanged();
        /// <summary>
        /// There are no comments for Property ExpireDate in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public global::System.DateTime ExpireDate
        {
            get
            {
                return this._ExpireDate;
            }
            set
            {
                this.OnExpireDateChanging(value);
                this.ReportPropertyChanging("ExpireDate");
                this._ExpireDate = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value);
                this.ReportPropertyChanged("ExpireDate");
                this.OnExpireDateChanged();
            }
        }
        private global::System.DateTime _ExpireDate;
        partial void OnExpireDateChanging(global::System.DateTime value);
        partial void OnExpireDateChanged();
    }
}
