﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="timmins")]
public partial class subscriberDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void Inserttbl_subscriber(tbl_subscriber instance);
  partial void Updatetbl_subscriber(tbl_subscriber instance);
  partial void Deletetbl_subscriber(tbl_subscriber instance);
  #endregion
	
	public subscriberDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["timminsConnectionString1"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public subscriberDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public subscriberDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public subscriberDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public subscriberDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<tbl_subscriber> tbl_subscribers
	{
		get
		{
			return this.GetTable<tbl_subscriber>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="timmins.tbl_subscribers")]
public partial class tbl_subscriber : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _subscriber_id;
	
	private string _name;
	
	private string _email;
	
	private string _valid;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onsubscriber_idChanging(int value);
    partial void Onsubscriber_idChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnvalidChanging(string value);
    partial void OnvalidChanged();
    #endregion
	
	public tbl_subscriber()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_subscriber_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int subscriber_id
	{
		get
		{
			return this._subscriber_id;
		}
		set
		{
			if ((this._subscriber_id != value))
			{
				this.Onsubscriber_idChanging(value);
				this.SendPropertyChanging();
				this._subscriber_id = value;
				this.SendPropertyChanged("subscriber_id");
				this.Onsubscriber_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50)")]
	public string name
	{
		get
		{
			return this._name;
		}
		set
		{
			if ((this._name != value))
			{
				this.OnnameChanging(value);
				this.SendPropertyChanging();
				this._name = value;
				this.SendPropertyChanged("name");
				this.OnnameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="VarChar(80) NOT NULL", CanBeNull=false)]
	public string email
	{
		get
		{
			return this._email;
		}
		set
		{
			if ((this._email != value))
			{
				this.OnemailChanging(value);
				this.SendPropertyChanging();
				this._email = value;
				this.SendPropertyChanged("email");
				this.OnemailChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_valid", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
	public string valid
	{
		get
		{
			return this._valid;
		}
		set
		{
			if ((this._valid != value))
			{
				this.OnvalidChanging(value);
				this.SendPropertyChanging();
				this._valid = value;
				this.SendPropertyChanged("valid");
				this.OnvalidChanged();
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
#pragma warning restore 1591