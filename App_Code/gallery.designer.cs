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



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Timmins")]
public partial class galleryDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertGallery(Gallery instance);
  partial void UpdateGallery(Gallery instance);
  partial void DeleteGallery(Gallery instance);
  #endregion
	
	public galleryDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["TimminsConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public galleryDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public galleryDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public galleryDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public galleryDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Gallery> Galleries
	{
		get
		{
			return this.GetTable<Gallery>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="timmins.Gallery")]
public partial class Gallery : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _MainImage;
	
	private string _ThumbNail;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnMainImageChanging(string value);
    partial void OnMainImageChanged();
    partial void OnThumbNailChanging(string value);
    partial void OnThumbNailChanged();
    #endregion
	
	public Gallery()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MainImage", DbType="VarChar(50)")]
	public string MainImage
	{
		get
		{
			return this._MainImage;
		}
		set
		{
			if ((this._MainImage != value))
			{
				this.OnMainImageChanging(value);
				this.SendPropertyChanging();
				this._MainImage = value;
				this.SendPropertyChanged("MainImage");
				this.OnMainImageChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThumbNail", DbType="VarChar(MAX)")]
	public string ThumbNail
	{
		get
		{
			return this._ThumbNail;
		}
		set
		{
			if ((this._ThumbNail != value))
			{
				this.OnThumbNailChanging(value);
				this.SendPropertyChanging();
				this._ThumbNail = value;
				this.SendPropertyChanged("ThumbNail");
				this.OnThumbNailChanged();
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
