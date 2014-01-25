using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GridTools;
using System.Collections;
using System.Linq.Expressions;
using MyExpressLane.Repository.Models;

namespace MyExpressLane.Repository
{
    public class GridFactory<T> where T:class
    {
        protected static Hashtable grid_functions = new Hashtable();
        public delegate JQGridData GridFormatter(GridPaging paging);
        public delegate JQGridData GridFormatter2(string eid, GridPaging paging);
        
        public Expression<Func<T, bool>> expression { get; set; }
        //public string Parameter { get; set; }
        //public int SearchID { get; set; }
        //public DateTime SearchDate { get; set; }
        //public DateTime? SearchDateOptional { get; set; }

        public GridFactory()
        {
            RegisterGrids();
        }

        protected void RegisterGrids()
        {
            //RegisterGridFormatter("GetGrid", GetGrid);
            /* Keep in modular and then alphabetical order */
            //RegisterGridFormatter("GetDormantData", GetDormantData);
            //RegisterGridFormatter("GetUserGrid", GetUserGrid);
            //RegisterGridFormatter("GetRequestHistory", GetRequestHistory);
            //RegisterGridFormatter("GetMyRequest", GetMyRequest);
            //RegisterGridFormatter("GetLastAssigned", GetLastAssigned);
            //RegisterGridFormatter("GetMyTeamQueue", GetMyTeamQueue);
            //RegisterGridFormatter("GetMyQueue", GetMyQueue);
            //RegisterGridFormatter("GetRequestAssignment", GetRequestAssignment);
            //RegisterGridFormatter("GetRequestForApproval", GetRequestForApproval);
            //RegisterGridFormatter("GetRoleByUserId", GetRoleByUserId);
            //RegisterGridFormatter("SearchRequest", SearchRequest);
            //RegisterGridFormatter("GetTestGrid", GetTestGrid);

        }

        #region Methods

        //public GridFactory AddRequestCondition(Expression<Func<MELRequest, bool>> condition)
        //{
        //    this.RequestCondition = condition;
        //    return this;
        //}

        //public GridFactory AddParameter(string parameter)
        //{
        //    if (string.IsNullOrEmpty(Parameter))
        //    {
        //        this.Parameter = parameter;
        //        return this;
        //    }
        //    return this;
        //}

        //public GridFactory AddSearchDate(DateTime date)
        //{
        //    this.SearchDate = date;
        //    return this;
        //}

        //public GridFactory AddSearchDate(DateTime? date)
        //{
        //    this.SearchDateOptional = date;
        //    return this;
        //}

        //public GridFactory AddSearchID(int id)
        //{
        //    this.SearchID = id;
        //    return this;
        //}

        #endregion

        #region GridCore

        protected void RegisterGridFormatter(string format,GridFormatter method)
        {
            grid_functions[format] = new GridFormatter(method);
        }

        public JQGridData GridData(string format,GridPaging paging)
        {
            var trim_format = format.Trim();
            foreach (string grid_format in grid_functions.Keys)
            {
                if (trim_format.ToLower() == grid_format.ToLower())
                {
                    var method = (GridFormatter)grid_functions[grid_format];
                    return method(paging);
                }
            }
           
            throw new Exception("Invalid format for GridData method");
        }

        #endregion

        #region Grid Data
        protected JQGridData GetGrid(IQueryable<T> data, string[] colname, GridPaging paging) 
        {
            
            return data.ToJQGridData(paging, colname);
        }
        //protected JQGridData GetDormantData(GridPaging paging)
        //{
        //    return DormantData.GetAll().Select(d => new
        //    {
        //        id = d.id,
        //        project = d.project,
        //        name = d.name,
        //        status = d.status,
        //        userName = d.username,
        //        dateCreated = d.date_created.ToString(),
        //        dateChanged = d.date_changed.ToString(),
        //        lastLogon = d.last_logon,
        //        lastPasswordChanged = d.last_pw_changed.ToString(),
        //        distinguishedName = d.distinguished_name

        //    }).ToJQGridData(paging, new[] {"id", "project", "name", "status", "userName", "dateCreated", "dateChanged",
        //        "lastLogon", "lastPasswordChanged", "distinguishedName" });
        //}
        //protected JQGridData GetUserGrid(GridPaging paging)
        //{
        //    return MELUser.GetAll().Select(u => new
        //    {
        //        userId = u.userId,
        //        eId =  u.eId,
        //        email = u.email,
        //        employeeNo = u.employeeNo,
        //        employeeStatus = u.employeeStatus,
        //        modifyBy = u.modifyBy,
        //        modifyDate = u.modifyDate

        //    }).ToJQGridData(paging, new[] { "userId", "eId", "email", "employeeNo", "employeeStatus", 
        //                                        "modifyBy", "modifyDate" });
        //}
        //protected JQGridData GetRequestHistory(GridPaging paging)
        //{
        //    return RequestHistory.GetByRequestId(SearchID).Select(r => new
        //    {
        //        historyId = r.historyId,
        //        eId = r.eId,
        //        date = r.date.ToString(),
        //        remarks = r.remarks,
        //        status = r.status,
        //        assignedTo = r.assignedTo

        //    }).ToJQGridData(paging, new[] { "historyId", "eId", "date", "assignedTo", "remarks", "status" });
        //}
        //protected JQGridData GetMyRequest(GridPaging paging)
        //{
        //    return MELRequest.GetMyRequest(Parameter).Select(r => new
        //    {
        //        requestId = r.requestId,
        //        requestNo = r.requestNo,
        //        date = r.date.ToString(),
        //        requestTypeName = r.requestTypeName,
        //        summary = r.summary,
        //        status = r.status,
        //        assignedTo = r.assignedTo

        //    }).ToJQGridData(paging, new[] { "requestId", "requestNo", "date", "requestTypeName", 
        //                                        "summary", "status", "assignedTo" });
        //}
        //protected JQGridData SearchRequest(GridPaging paging)
        //{
        //    var request = MELRequest.SearchRequest(Parameter);

        //    return request.Select(r => new
        //    {
        //        requestId = r.requestId,
        //        requestNo = r.requestNo,
        //        eId = r.requestEid,
        //        requiredDate = r.requiredDate,
        //        requestTypeName = r.requestTypeName,
        //        status = r.status,
        //        summary = r.summary,
        //        assignedTo = r.assignedTo,
        //        assignedDate = r.assignedDate,
        //        userProfile = r.userProfile,
        //        priorityLevel = r.priorityLevel

        //    }).ToJQGridData(paging, new[] { "requestId", "requestNo", "eId", "requiredDate", "requestTypeName", 
        //                                        "status", "summary", "assignedTo", "assignedDate", "userProfile", "priorityLevel" });
        //}
        //protected JQGridData GetTestGrid(GridPaging paging) {
        //    return RequestType.GetAll().Select(x => new
        //    {
        //        id = x.requestTypeId,
        //        requesttype = x.requestTypeName,
        //        tags = x.tags

        //    }).ToJQGridData(paging, new[] { "id","requesttype","tags"});

        //}
        //protected JQGridData GetLastAssigned(GridPaging paging)
        //{
        //    var request = MELRequest.GetLastAssigned(Parameter);

        //    return request.Select(r => new
        //    {
        //        requestId = r.requestId,
        //        requestNo = r.requestNo,
        //        eId = r.requestEid,
        //        requiredDate = r.requiredDate,
        //        requestTypeName = r.requestTypeName,
        //        status = r.status,
        //        summary = r.summary,
        //        assignedTo = r.assignedTo,
        //        assignedDate = r.assignedDate,
        //        userProfile = r.userProfile,
        //        priorityLevel = r.priorityLevel

        //    }).ToJQGridData(paging, new[] { "requestId", "requestNo", "eId", "requiredDate", "requestTypeName", 
        //                                        "status", "summary", "assignedTo", "assignedDate", "userProfile", "priorityLevel" });
        //}
        //protected JQGridData GetMyTeamQueue(GridPaging paging)
        //{
        //    var request = MELRequest.GetMyTeamQueue();
        //    if (RequestCondition != null)
        //        request = MELRequest.GetMyTeamQueue(RequestCondition);

        //    return request.Select(r => new
        //    {
        //        requestId = r.requestId,
        //        requestNo = r.requestNo,
        //        eId = r.requestEid,
        //        requiredDate = r.requiredDate,
        //        requestTypeName = r.requestTypeName,
        //        status = r.status,
        //        summary = r.summary,
        //        assignedTo = r.assignedTo,
        //        assignedDate = r.assignedDate,
        //        userProfile = r.userProfile,
        //        priorityLevel = r.priorityLevel

        //    }).ToJQGridData(paging, new[] { "requestId", "requestNo", "eId", "requiredDate", "requestTypeName", 
        //                                        "status", "summary", "assignedTo", "assignedDate", "userProfile", "priorityLevel" });
        //}
        //protected JQGridData GetMyQueue(GridPaging paging)
        //{
        //    var request = MELRequest.GetMyQueue(Parameter);
        //    if (RequestCondition != null)
        //        request = MELRequest.GetMyQueue(RequestCondition, Parameter);

        //    return request.Select(r => new
        //    {
        //        requestId = r.requestId,
        //        requestNo = r.requestNo,
        //        requestTypeName = r.requestTypeName,
        //        eId = r.requestEid,
        //        requiredDate = r.requiredDate,
        //        status = r.status,
        //        remarks = r.remarks,
        //        userProfile = r.userProfile

        //    }).ToJQGridData(paging, new[] { "requestId", "requestNo", "eId", "requiredDate", "requestTypeName", 
        //                                        "status", "remarks", "userProfile" });
        //}
        //protected JQGridData GetRequestAssignment(GridPaging paging)
        //{
        //    var request = MELRequest.GetRequestAssignment();
        //    if (RequestCondition != null)
        //        request = MELRequest.GetRequestAssignment(RequestCondition);

        //    return request.Select(r => new
        //    {
        //        requestId = r.requestId,
        //        requestNo = r.requestNo,
        //        date = r.date.ToString(),
        //        requestTypeName = r.requestTypeName,
        //        summary = r.summary,
        //        status = r.status,
        //        assignedTo = r.assignedTo

        //    }).ToJQGridData(paging, new[] { "requestId", "requestNo", "date", "requestTypeName", 
        //                                        "summary", "status", "assignedTo" });
        //}
        //protected JQGridData GetRequestForApproval(GridPaging paging)
        //{
        //    return MELRequest.GetRequestForApproval().Select(r => new
        //    {
        //        requestId = r.requestId,
        //        requestNo = r.requestNo,
        //        date = r.date,
        //        requestTypeName = r.requestTypeName,
        //        summary = r.summary,
        //        status = r.status,
        //        assignedTo = r.assignedTo

        //    }).ToJQGridData(paging, new[] { "requestId", "requestNo", "date", "requestTypeName", 
        //                                        "summary", "status", "assignedTo" });
        //}
        //protected JQGridData GetRoleByUserId(GridPaging paging)
        //{
        //    return UserRole.GetRoleByUserId(SearchID).Select(r => new
        //    {
        //        roleId = r.roleId,
        //        eId = r.MELUser.eId,
        //        user = r.MELUser.userName,
        //        email = r.MELUser.email,
        //        employeeNo = r.MELUser.employeeNo,
        //        employeeStatus = r.MELUser.employeeStatus


        //    }).ToJQGridData(paging, new[] { "roleId", "eId", "email", "employeeNo", "employeeStatus" });
        //}
        #endregion
    }
}