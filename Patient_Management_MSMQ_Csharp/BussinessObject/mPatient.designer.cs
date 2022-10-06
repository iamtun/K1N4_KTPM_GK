﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BussinessObject
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="patient_management")]
	public partial class mPatientDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertdoctor(doctor instance);
    partial void Updatedoctor(doctor instance);
    partial void Deletedoctor(doctor instance);
    partial void Insertmedical_examination(medical_examination instance);
    partial void Updatemedical_examination(medical_examination instance);
    partial void Deletemedical_examination(medical_examination instance);
    partial void Insertpatient(patient instance);
    partial void Updatepatient(patient instance);
    partial void Deletepatient(patient instance);
    #endregion
		
		public mPatientDataContext() : 
				base(global::BussinessObject.Properties.Settings.Default.patient_managementConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public mPatientDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public mPatientDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public mPatientDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public mPatientDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<doctor> doctors
		{
			get
			{
				return this.GetTable<doctor>();
			}
		}
		
		public System.Data.Linq.Table<medical_examination> medical_examinations
		{
			get
			{
				return this.GetTable<medical_examination>();
			}
		}
		
		public System.Data.Linq.Table<patient> patients
		{
			get
			{
				return this.GetTable<patient>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.doctor")]
	public partial class doctor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _id;
		
		private string _full_name;
		
		private EntitySet<medical_examination> _medical_examinations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(string value);
    partial void OnidChanged();
    partial void Onfull_nameChanging(string value);
    partial void Onfull_nameChanged();
    #endregion
		
		public doctor()
		{
			this._medical_examinations = new EntitySet<medical_examination>(new Action<medical_examination>(this.attach_medical_examinations), new Action<medical_examination>(this.detach_medical_examinations));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="VarChar(15) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_full_name", DbType="NVarChar(150)")]
		public string full_name
		{
			get
			{
				return this._full_name;
			}
			set
			{
				if ((this._full_name != value))
				{
					this.Onfull_nameChanging(value);
					this.SendPropertyChanging();
					this._full_name = value;
					this.SendPropertyChanged("full_name");
					this.Onfull_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="doctor_medical_examination", Storage="_medical_examinations", ThisKey="id", OtherKey="doctor_id")]
		public EntitySet<medical_examination> medical_examinations
		{
			get
			{
				return this._medical_examinations;
			}
			set
			{
				this._medical_examinations.Assign(value);
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
		
		private void attach_medical_examinations(medical_examination entity)
		{
			this.SendPropertyChanging();
			entity.doctor = this;
		}
		
		private void detach_medical_examinations(medical_examination entity)
		{
			this.SendPropertyChanging();
			entity.doctor = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.medical_examination")]
	public partial class medical_examination : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _patient_id;
		
		private string _doctor_id;
		
		private System.DateTime _exam_date;
		
		private string _note;
		
		private EntityRef<doctor> _doctor;
		
		private EntityRef<patient> _patient;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onpatient_idChanging(string value);
    partial void Onpatient_idChanged();
    partial void Ondoctor_idChanging(string value);
    partial void Ondoctor_idChanged();
    partial void Onexam_dateChanging(System.DateTime value);
    partial void Onexam_dateChanged();
    partial void OnnoteChanging(string value);
    partial void OnnoteChanged();
    #endregion
		
		public medical_examination()
		{
			this._doctor = default(EntityRef<doctor>);
			this._patient = default(EntityRef<patient>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_patient_id", DbType="VarChar(15) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string patient_id
		{
			get
			{
				return this._patient_id;
			}
			set
			{
				if ((this._patient_id != value))
				{
					if (this._patient.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onpatient_idChanging(value);
					this.SendPropertyChanging();
					this._patient_id = value;
					this.SendPropertyChanged("patient_id");
					this.Onpatient_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_doctor_id", DbType="VarChar(15) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string doctor_id
		{
			get
			{
				return this._doctor_id;
			}
			set
			{
				if ((this._doctor_id != value))
				{
					if (this._doctor.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Ondoctor_idChanging(value);
					this.SendPropertyChanging();
					this._doctor_id = value;
					this.SendPropertyChanged("doctor_id");
					this.Ondoctor_idChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_exam_date", DbType="Date NOT NULL")]
		public System.DateTime exam_date
		{
			get
			{
				return this._exam_date;
			}
			set
			{
				if ((this._exam_date != value))
				{
					this.Onexam_dateChanging(value);
					this.SendPropertyChanging();
					this._exam_date = value;
					this.SendPropertyChanged("exam_date");
					this.Onexam_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_note", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string note
		{
			get
			{
				return this._note;
			}
			set
			{
				if ((this._note != value))
				{
					this.OnnoteChanging(value);
					this.SendPropertyChanging();
					this._note = value;
					this.SendPropertyChanged("note");
					this.OnnoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="doctor_medical_examination", Storage="_doctor", ThisKey="doctor_id", OtherKey="id", IsForeignKey=true)]
		public doctor doctor
		{
			get
			{
				return this._doctor.Entity;
			}
			set
			{
				doctor previousValue = this._doctor.Entity;
				if (((previousValue != value) 
							|| (this._doctor.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._doctor.Entity = null;
						previousValue.medical_examinations.Remove(this);
					}
					this._doctor.Entity = value;
					if ((value != null))
					{
						value.medical_examinations.Add(this);
						this._doctor_id = value.id;
					}
					else
					{
						this._doctor_id = default(string);
					}
					this.SendPropertyChanged("doctor");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="patient_medical_examination", Storage="_patient", ThisKey="patient_id", OtherKey="id", IsForeignKey=true)]
		public patient patient
		{
			get
			{
				return this._patient.Entity;
			}
			set
			{
				patient previousValue = this._patient.Entity;
				if (((previousValue != value) 
							|| (this._patient.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._patient.Entity = null;
						previousValue.medical_examinations.Remove(this);
					}
					this._patient.Entity = value;
					if ((value != null))
					{
						value.medical_examinations.Add(this);
						this._patient_id = value.id;
					}
					else
					{
						this._patient_id = default(string);
					}
					this.SendPropertyChanged("patient");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.patient")]
	public partial class patient : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _id;
		
		private string _identity_number;
		
		private string _full_name;
		
		private string _address;
		
		private EntitySet<medical_examination> _medical_examinations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(string value);
    partial void OnidChanged();
    partial void Onidentity_numberChanging(string value);
    partial void Onidentity_numberChanged();
    partial void Onfull_nameChanging(string value);
    partial void Onfull_nameChanged();
    partial void OnaddressChanging(string value);
    partial void OnaddressChanged();
    #endregion
		
		public patient()
		{
			this._medical_examinations = new EntitySet<medical_examination>(new Action<medical_examination>(this.attach_medical_examinations), new Action<medical_examination>(this.detach_medical_examinations));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="VarChar(15) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_identity_number", DbType="VarChar(15) NOT NULL", CanBeNull=false)]
		public string identity_number
		{
			get
			{
				return this._identity_number;
			}
			set
			{
				if ((this._identity_number != value))
				{
					this.Onidentity_numberChanging(value);
					this.SendPropertyChanging();
					this._identity_number = value;
					this.SendPropertyChanged("identity_number");
					this.Onidentity_numberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_full_name", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
		public string full_name
		{
			get
			{
				return this._full_name;
			}
			set
			{
				if ((this._full_name != value))
				{
					this.Onfull_nameChanging(value);
					this.SendPropertyChanging();
					this._full_name = value;
					this.SendPropertyChanged("full_name");
					this.Onfull_nameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_address", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
		public string address
		{
			get
			{
				return this._address;
			}
			set
			{
				if ((this._address != value))
				{
					this.OnaddressChanging(value);
					this.SendPropertyChanging();
					this._address = value;
					this.SendPropertyChanged("address");
					this.OnaddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="patient_medical_examination", Storage="_medical_examinations", ThisKey="id", OtherKey="patient_id")]
		public EntitySet<medical_examination> medical_examinations
		{
			get
			{
				return this._medical_examinations;
			}
			set
			{
				this._medical_examinations.Assign(value);
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
		
		private void attach_medical_examinations(medical_examination entity)
		{
			this.SendPropertyChanging();
			entity.patient = this;
		}
		
		private void detach_medical_examinations(medical_examination entity)
		{
			this.SendPropertyChanging();
			entity.patient = null;
		}
	}
}
#pragma warning restore 1591
