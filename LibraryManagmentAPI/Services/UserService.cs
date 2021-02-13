using LibraryManagmentAPI.Interface;
using LibraryManagmentAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static LibraryManagmentAPI.Utilities.Utilities;

namespace LibraryManagmentAPI.Services
{
    public class UserService : IUser
    {
        public JsonResponse Add(User model)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                SqlParameter[] objParam = new SqlParameter[6];
                objParam[0] = new SqlParameter("@ID", model.ID);
                objParam[1] = new SqlParameter("@Name", model.Name);
                objParam[2] = new SqlParameter("@UserName", model.UserName);
                objParam[3] = new SqlParameter("@Password", model.Password);
                objParam[4] = new SqlParameter("@Role", model.Role);
                objParam[5] = new SqlParameter("@Flag", 1);
                DataSet dataSet = ExecuteDataset(Procedures.ManageUser, objParam);
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    // check 1st table  session exist or not
                    DataTable statusDataTable = dataSet.Tables[0];
                    if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                    {
                        jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                        jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                    }
                    else
                    {
                        jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                        jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                    }
                }
                else
                {
                    jsonResponse.Status = ResponseStatus.Failed;
                    jsonResponse.Message = ResponseMessages.ServerError;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResponse;
        }

        public JsonResponse Delete(long ID)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                if (ID != 0)
                {
                    SqlParameter[] objParam = new SqlParameter[2];
                    objParam[0] = new SqlParameter("@Flag", 5);
                    objParam[1] = new SqlParameter("@ID", ID);
                    DataSet dataSet = ExecuteDataset(Procedures.ManageUser, objParam);
                    if (dataSet != null && dataSet.Tables.Count > 0)
                    {
                        // check 1st table  session exist or not
                        DataTable statusDataTable = dataSet.Tables[0];
                        if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                        else
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                    }
                    else
                    {
                        jsonResponse.Status = ResponseStatus.Failed;
                        jsonResponse.Message = ResponseMessages.ServerError;
                    }
                }
                else
                {
                    jsonResponse.Status = ResponseStatus.Failed;
                    if (ID == 0) { jsonResponse.Message = ResponseMessages.InvalidIdentity; }
                    else { jsonResponse.Message = ResponseMessages.ServerError; }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResponse;
        }

        public JsonResponse FetchAll()
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                SqlParameter[] objParam = new SqlParameter[1];
                objParam[0] = new SqlParameter("@Flag", 3);
                DataSet dataSet = ExecuteDataset(Procedures.ManageUser, objParam);
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    // check 1st table  session exist or not
                    DataTable statusDataTable = dataSet.Tables[0];
                    if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                    {
                        jsonResponse = dataSet.Tables[0].AsEnumerable().Select(a => new JsonResponse
                        {
                            Status = a.Field<string>("STATUS"),
                            Message = a.Field<string>("MESSAGE")
                        }).FirstOrDefault();
                        if (dataSet.Tables.Count > 1)
                        {
                            if (dataSet.Tables[1] != null && dataSet.Tables[1].Rows.Count > 0)
                            {
                                jsonResponse.Data = dataSet.Tables[1].AsEnumerable().Select(a => new User
                                {
                                    ID = a.Field<long>("ID"),
                                    Name = a.Field<string>("Name"),
                                    UserName = a.Field<string>("UserName"),
                                    Password = a.Field<string>("Password"),
                                    Role = a.Field<int>("Role"),
                                    IsActive = a.Field<bool>("IsActive"),
                                }).ToList();
                            }
                        }
                    }
                }
                else
                {
                    jsonResponse.Status = ResponseStatus.Failed;
                    jsonResponse.Message = ResponseMessages.ServerError;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResponse;
        }

        public JsonResponse FetchByID(long ID)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                if (ID != 0)
                {
                    SqlParameter[] objParam = new SqlParameter[2];
                    objParam[0] = new SqlParameter("@Flag", 4);
                    objParam[1] = new SqlParameter("@ID", ID);
                    DataSet dataSet = ExecuteDataset(Procedures.ManageUser, objParam);
                    if (dataSet != null && dataSet.Tables.Count > 0)
                    {
                        // check 1st table  session exist or not
                        DataTable statusDataTable = dataSet.Tables[0];
                        if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                        {
                            jsonResponse = dataSet.Tables[0].AsEnumerable().Select(a => new JsonResponse
                            {
                                Status = a.Field<string>("STATUS"),
                                Message = a.Field<string>("MESSAGE")
                            }).FirstOrDefault();
                            if (dataSet.Tables.Count > 1)
                            {
                                if (dataSet.Tables[1] != null && dataSet.Tables[1].Rows.Count > 0)
                                {
                                    jsonResponse.Data = dataSet.Tables[1].AsEnumerable().Select(a => new User
                                    {
                                        ID = a.Field<long>("ID"),
                                        Name = a.Field<string>("Name"),
                                        UserName = a.Field<string>("UserName"),
                                        Password = a.Field<string>("Password"),
                                        Role = a.Field<int>("Role"),
                                        IsActive = a.Field<bool>("IsActive"),
                                    });
                                }
                            }
                            else
                            {
                                jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                                jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                            }
                        }
                        else
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                    }
                    else
                    {
                        jsonResponse.Status = ResponseStatus.Failed;
                        jsonResponse.Message = ResponseMessages.ServerError;
                    }
                }
                else
                {
                    jsonResponse.Status = ResponseStatus.Failed;
                    if (ID == 0) { jsonResponse.Message = ResponseMessages.InvalidIdentity; }
                    else { jsonResponse.Message = ResponseMessages.ServerError; }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return jsonResponse;
        }

        public JsonResponse Update(User model)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                if (model.ID != 0)
                {
                    SqlParameter[] objParam = new SqlParameter[6];
                    objParam[0] = new SqlParameter("@ID", model.ID);
                    objParam[1] = new SqlParameter("@Name", model.Name);
                    objParam[2] = new SqlParameter("@UserName", model.UserName);
                    objParam[3] = new SqlParameter("@Password", model.Password);
                    objParam[4] = new SqlParameter("@Role", model.Role);
                    objParam[5] = new SqlParameter("@Flag", 2);
                    DataSet dataSet = ExecuteDataset(Procedures.ManageUser, objParam);
                    if (dataSet != null && dataSet.Tables.Count > 0)
                    {
                        // check 1st table  session exist or not
                        DataTable statusDataTable = dataSet.Tables[0];
                        if (statusDataTable != null && statusDataTable.Rows.Count > 0 && statusDataTable.Rows[0]["STATUS"] != null && statusDataTable.Rows[0]["STATUS"].ToString() == "S")
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                        else
                        {
                            jsonResponse.Status = statusDataTable.Rows[0]["STATUS"].ToString();
                            jsonResponse.Message = statusDataTable.Rows[0]["MESSAGE"].ToString();
                        }
                    }
                    else
                    {
                        jsonResponse.Status = ResponseStatus.Failed;
                        jsonResponse.Message = ResponseMessages.ServerError;
                    }
                }
                else
                {
                    jsonResponse.Status = ResponseStatus.Failed;
                    if (model.ID == 0) { jsonResponse.Message = ResponseMessages.InvalidIdentity; }
                    else { jsonResponse.Message = ResponseMessages.ServerError; }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return jsonResponse;
        }
    }
}