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
    public class BookService : IBook
    {
        public JsonResponse Add(Book model)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                SqlParameter[] objParam = new SqlParameter[8];
                objParam[0] = new SqlParameter("@ID", model.ID);
                objParam[1] = new SqlParameter("@Name", model.Name);
                objParam[2] = new SqlParameter("@Aauthor", model.Aauthor);
                objParam[3] = new SqlParameter("@Publisher", model.Publisher);
                objParam[4] = new SqlParameter("@Category", model.Category);
                objParam[5] = new SqlParameter("@Price", model.Price);
                objParam[6] = new SqlParameter("@Image", model.Image);
                objParam[7] = new SqlParameter("@Flag", 1);
                DataSet dataSet = ExecuteDataset(Procedures.ManageBook, objParam);
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
                    DataSet dataSet = ExecuteDataset(Procedures.ManageBook, objParam);
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
                DataSet dataSet = ExecuteDataset(Procedures.ManageBook, objParam);
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
                                jsonResponse.Data = dataSet.Tables[1].AsEnumerable().Select(a => new Book
                                {
                                    ID = a.Field<long>("ID"),
                                    Name = a.Field<string>("Name"),
                                    Aauthor = a.Field<string>("Aauthor"),
                                    Category = a.Field<int>("Category"),
                                    Price = Convert.ToInt32(a.Field<Decimal>("Price")),
                                    Publisher = a.Field<string>("Publisher"),
                                    Image = a.Field<string>("Image"),
                                    IsActive = a.Field<bool>("IsActive"),
                                }).ToList();
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
                    DataSet dataSet = ExecuteDataset(Procedures.ManageBook, objParam);
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
                                    jsonResponse.Data = dataSet.Tables[1].AsEnumerable().Select(a => new Book
                                    {
                                        ID = a.Field<long>("ID"),
                                        Name = a.Field<string>("Name"),
                                        Aauthor = a.Field<string>("Aauthor"),
                                        Category = a.Field<int>("Category"),
                                        Price = Convert.ToInt32(a.Field<Decimal>("Price")),
                                        Publisher = a.Field<string>("Publisher"),
                                        Image = a.Field<string>("Image"),
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

        public JsonResponse Update(Book model)
        {
            JsonResponse jsonResponse = new JsonResponse();
            try
            {
                if (model.ID != 0)
                {
                    SqlParameter[] objParam = new SqlParameter[8];
                    objParam[0] = new SqlParameter("@ID", model.ID);
                    objParam[1] = new SqlParameter("@Name", model.Name);
                    objParam[2] = new SqlParameter("@Aauthor", model.Aauthor);
                    objParam[3] = new SqlParameter("@Publisher", model.Publisher);
                    objParam[4] = new SqlParameter("@Category", model.Category);
                    objParam[5] = new SqlParameter("@Price", model.Price);
                    objParam[6] = new SqlParameter("@Image", model.Image);
                    objParam[7] = new SqlParameter("@Flag", 2);
                    DataSet dataSet = ExecuteDataset(Procedures.ManageBook, objParam);
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