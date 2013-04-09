using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for services_department
/// </summary>
public class services_department
{
	
    //  get services
	public IQueryable<tbl_service> getServices()
	{
		DataClassesDataContext objserDC = new DataClassesDataContext();
		var allservices = objserDC.tbl_services.Select(x => x).OrderBy(x => x.title);// by default order by is in ascending
		return allservices;
		
	}

    // get services by date
    public IQueryable<tbl_service> getservicesBydate()
    {
        DataClassesDataContext objserDC = new DataClassesDataContext();
        var allservices = objserDC.tbl_services.Select(x => x).OrderByDescending(x => x.date);// by default order by is in ascending
        return allservices;
    
    
    }

	// get services by ID
	public IQueryable<tbl_service> getServiceByID(int _id)
	{
		DataClassesDataContext objserDC = new DataClassesDataContext();
		var allservices = objserDC.tbl_services.Where(x => x.service_id == _id).Select(x => x);
		return allservices;
	
	}






	public bool CommitInsert( string _title, string _des, DateTime _Date)
	{
		DataClassesDataContext objserDC = new DataClassesDataContext();
		using (objserDC)
		{ 
		// create an instance of table
			tbl_service objNewSer = new tbl_service();
			objNewSer.title = _title;
			objNewSer.description = _des;
            objNewSer.date = _Date;
			objserDC.tbl_services.InsertOnSubmit(objNewSer);

			objserDC.SubmitChanges();
			return true;
		}
	}

    public bool CommitUpdate(int _id, string _title, string _des, DateTime _Date)
	{
		DataClassesDataContext objserDC = new DataClassesDataContext();
		using (objserDC)
		{
					 
			 var objUpSer = objserDC.tbl_services.Single(x => x.service_id == _id);
			 objUpSer.title = _title;
			 objUpSer.description = _des;
             objUpSer.date = _Date.Date;
			
			 objserDC.SubmitChanges();
			 return true;
		
		}
	}

	public bool CommitDelete(int _id)
	{
		DataClassesDataContext objserDC = new DataClassesDataContext();
		using (objserDC)
		{
			var objDelser = objserDC.tbl_services.Single(x => x.service_id == _id);

			objserDC.tbl_services.DeleteOnSubmit(objDelser);
			objserDC.SubmitChanges();
			return true;
		}
   
	}

}