﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
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



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="anjag_sql")]
public partial class subjectDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void Insertsubject(subject instance);
  partial void Updatesubject(subject instance);
  partial void Deletesubject(subject instance);
  #endregion
	
	public subjectDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["anjag_sqlConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public subjectDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public subjectDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public subjectDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public subjectDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<subject> subjects
	{
		get
		{
			return this.GetTable<subject>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="anjag_1.subject")]
public partial class subject : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _id;
	
	private string _menu_name;
	
	private System.Nullable<decimal> _position;
	
	private System.Nullable<bool> _visible;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onmenu_nameChanging(string value);
    partial void Onmenu_nameChanged();
    partial void OnpositionChanging(System.Nullable<decimal> value);
    partial void OnpositionChanged();
    partial void OnvisibleChanging(System.Nullable<bool> value);
    partial void OnvisibleChanged();
    #endregion
	
	public subject()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int id
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
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_menu_name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
	public string menu_name
	{
		get
		{
			return this._menu_name;
		}
		set
		{
			if ((this._menu_name != value))
			{
				this.Onmenu_nameChanging(value);
				this.SendPropertyChanging();
				this._menu_name = value;
				this.SendPropertyChanged("menu_name");
				this.Onmenu_nameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_position", DbType="Decimal(18,0)")]
	public System.Nullable<decimal> position
	{
		get
		{
			return this._position;
		}
		set
		{
			if ((this._position != value))
			{
				this.OnpositionChanging(value);
				this.SendPropertyChanging();
				this._position = value;
				this.SendPropertyChanged("position");
				this.OnpositionChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_visible", DbType="Bit")]
	public System.Nullable<bool> visible
	{
		get
		{
			return this._visible;
		}
		set
		{
			if ((this._visible != value))
			{
				this.OnvisibleChanging(value);
				this.SendPropertyChanging();
				this._visible = value;
				this.SendPropertyChanged("visible");
				this.OnvisibleChanged();
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
