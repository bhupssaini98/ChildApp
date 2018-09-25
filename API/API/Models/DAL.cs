using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class DAL
    {
        #region Local Variables
        private static string ConnectionString = string.Empty;
        #endregion

        #region Global Functions
        static DAL()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
        }
        #endregion

        public List<SelectList> GetGender()
        {
            DataSet dsData = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, CommanDataReader.GetGender);
            List<SelectList> gender = (from item in dsData.Tables[0].AsEnumerable()
                                        select new SelectList
                                        {
                                            Text = item.Field<string>("GenderName"),
                                            Value = Convert.ToString(item.Field<int>("GenderId"))
                                        }).ToList();


            return gender;
        }
        public SearchFilter GetSearchFilter()
        {
            DataSet dsfilter = SqlHelper.ExecuteDataset(ConnectionString,CommandType.StoredProcedure,CommanDataReader.GetSearchFilter);
            List<SelectList> gender = (from item in dsfilter.Tables[0].AsEnumerable()
                                       select new SelectList
                                       {
                                           Text = item.Field<string>("GenderName"),
                                           Value = Convert.ToString(item.Field<int>("GenderId"))
                                       }
                                     ).ToList();
            List<SelectList> type = (from item in dsfilter.Tables[1].AsEnumerable()
                                       select new SelectList
                                       {
                                           Text = item.Field<string>("TypeName"),
                                           Value = Convert.ToString(item.Field<int>("Id"))
                                       }
                                    ).ToList();
            List<SelectList> childRelation = (from item in dsfilter.Tables[2].AsEnumerable()
                                     select new SelectList
                                     {
                                         Text = item.Field<string>("RelationName"),
                                         Value = Convert.ToString(item.Field<int>("Id"))
                                     }
                                   ).ToList();
            List<SelectList> status = (from item in dsfilter.Tables[3].AsEnumerable()
                                              select new SelectList
                                              {
                                                  Text = item.Field<string>("StatusName"),
                                                  Value = Convert.ToString(item.Field<int>("Id"))
                                              }
                                  ).ToList();

            SearchFilter result = new SearchFilter()
            {
                Gender= gender,
                Type= type,
                ChildRelation= childRelation,
                Status= status
            };
            return result;
        }

        public ResponseMessage AddEditChildData(Childdetails child)
        {
            int ParamCount = 0;
            SqlParameter[] sqlParameters = new SqlParameter[50];
            sqlParameters[ParamCount] = new SqlParameter("@ChildId",SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.ChildID;ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@FirstName", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.ChildFirstName; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@LastName", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.ChildLastName; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@ChildBirthDate", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.ChildBirthDate; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@ChildAddress", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.ChildAddress; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@ChildGender", SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.ChildGender; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@ChildStatus", SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.ChildStatus; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@ChildType", SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.ChildType; ParamCount++;


            sqlParameters[ParamCount] = new SqlParameter("@Parent1FirstName", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1FirstName; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1LastName", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1LastName; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1Private", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1Private; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1Gender", SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.Parent1Gender; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1ChildRelation", SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.Parent1ChildRelation; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1Address", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1Address; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1Unit", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1Unit; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1City", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1City; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1Province", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1Province; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1PostalCode", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1PostalCode; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1HomePhone", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1HomePhone; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1WorkPhone", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1WorkPhone; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1CellPhone", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1CellPhone; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1Email", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1Email; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1PrimaryEmail", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1PrimaryEmail; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1Comments", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1Comments; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent1SpecialCustody", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1SpecialCustody; ParamCount++;

            sqlParameters[ParamCount] = new SqlParameter("@Parent2FirstName", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2FirstName; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2LastName", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2LastName; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2Private", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2Private; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2Gender", SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.Parent2Gender; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2ChildRelation", SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.Parent2ChildRelation; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2Address", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2Address; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2Unit", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2Unit; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2City", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2City; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2Province", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2Province; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2PostalCode", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2PostalCode; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2HomePhone", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2HomePhone; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2WorkPhone", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2WorkPhone; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2CellPhone", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2CellPhone; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2Email", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2Email; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2PrimaryEmail", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2PrimaryEmail; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2Comments", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent2Comments; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Parent2SpecialCustody", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Parent1SpecialCustody; ParamCount++;

            sqlParameters[ParamCount] = new SqlParameter("@SiblingName", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.SiblingName; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@SiblingAge", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.SiblingAge; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@SiblingGender", SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.SiblingGender; ParamCount++;

            sqlParameters[ParamCount] = new SqlParameter("@Contact1Name", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Contact1Name; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Contact1Phone", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Contact1Phone; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Contact1Email", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Contact1Email; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Contact1Address", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = child.Contact1Address; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@Contact1Relationship", SqlDbType.Int);
            sqlParameters[ParamCount].Value = child.Contact1Relationship; ParamCount++;


            DataSet dsData = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, CommanDataReader.AddEditChildData, sqlParameters);
            ResponseMessage result = (from item in dsData.Tables[0].AsEnumerable()
                                         select new ResponseMessage
                                         {
                                             ID=item.Field<int>("ID"),
                                             Message = item.Field<string>("Message"),
                                         }).SingleOrDefault();
            return result;
        }
        public ResponseMessage DeleteChildData(ItemList item)
        {
            int ParamCount = 0;
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[ParamCount] = new SqlParameter("@ChildId", SqlDbType.Int);
            sqlParameters[ParamCount].Value = item.ChildID;ParamCount++;

            DataSet dsData = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, CommanDataReader.DeleteChildData, sqlParameters);

            ResponseMessage result = (from set in dsData.Tables[0].AsEnumerable()

                                      select new ResponseMessage
                                      {
                                          ID = set.Field<int>("ID"),
                                          Message = set.Field<string>("Message"),
                                      }
                                    ).SingleOrDefault();
            return result;
        }
        public List<Childdetails> GetChilddetails(RequestParams request)
        {
            int ParamCount = 0;
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[ParamCount] = new SqlParameter("@FirstName", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = request.ChildFirstName; ParamCount++;
            sqlParameters[ParamCount] = new SqlParameter("@LastName", SqlDbType.VarChar, 100);
            sqlParameters[ParamCount].Value = request.ChildLastName; ParamCount++;
           

            DataSet dsData = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, CommanDataReader.GetChilddetails, sqlParameters);
            List<Childdetails> Childs = (from item in dsData.Tables[0].AsEnumerable()
                               select new Childdetails
                               {

                                   ChildID = item.Field<int>("ChildID"),
                                   ChildLastName = item.Field<string>("Child Last Name"),
                                   ChildFirstName = item.Field<string>("Child First Name"),
                                   ChildGender = item.Field<int>("Child Gender"),
                                   ChildBirthDate = item.Field<string>("Child Birth Date"),
                                   ChildStatus = item.Field<int>("Child Status"),
                                   ChildAddress = item.Field<string>("Child Address"),
                                   //ChildType = item.Field<int>("Child Type"),
                                   Parent1LastName = item.Field<string>("Parent1 Last Name"),
                                   Parent1FirstName = item.Field<string>("Parent1 First Name"),
                                   //Parent1Private = item.Field<string>("Parent1 Private"),
                                   //Parent1Gender = item.Field<int>("Parent1 Gender"),
                                   //Parent1ChildRelation = item.Field<int>("Parent1 Child Relation"),
                                   Parent1Address = item.Field<string>("Parent1 Address"),
                                   Parent1Unit = item.Field<string>("Parent1 Unit"),
                                   Parent1City = item.Field<string>("Parent1 City"),
                                   //Parent1Province = item.Field<string>("Parent1 Province"),
                                   Parent1PostalCode = item.Field<string>("Parent1 Postal Code"),
                                   Parent1HomePhone = item.Field<string>("Parent1 Home Phone"),
                                   Parent1WorkPhone = item.Field<string>("Parent1 Work Phone"),
                                   Parent1CellPhone = item.Field<string>("Parent1 Cell Phone"),
                                   Parent1Email = item.Field<string>("Parent1 Email"),
                                   //Parent1PrimaryEmail = item.Field<bool>("Parent1 Primary Email"),
                                   //Parent1Comments = item.Field<string>("Parent1 Comments"),
                                   //Parent1SpecialCustody = item.Field<string>("Parent1 Special Custody"),
                                   //Parent2LastName = item.Field<string>("Parent2 Last Name"),
                                   //Parent2FirstName = item.Field<string>("Parent2 First Name"),
                                   //Parent2Private = item.Field<string>("Parent2 Private"),
                                   //Parent2Gender = item.Field<int>("Parent2 Gender"),
                                   //Parent2ChildRelation = item.Field<int>("Parent2 Child Relation"),
                                   //Parent2Address = item.Field<string>("Parent2 Address"),
                                   //Parent2Unit = item.Field<string>("Parent2 Unit"),
                                   //Parent2City = item.Field<string>("Parent2 City"),
                                   //Parent2Province = item.Field<string>("Parent2 Province"),
                                   //Parent2PostalCode = item.Field<string>("Parent2 Postal Code"),
                                   //Parent2HomePhone = item.Field<string>("Parent2 Home Phone"),
                                   //Parent2WorkPhone = item.Field<string>("Parent2 Work Phone"),
                                   //Parent2CellPhone = item.Field<string>("Parent2 Cell Phone"),
                                   //Parent2Email = item.Field<string>("Parent2 Email"),
                                   //Parent2PrimaryEmail = item.Field<bool>("Parent2 Primary Email"),
                                   //Parent2Comments = item.Field<string>("Parent2 Comments"),
                                   //Parent2SpecialCustody = item.Field<string>("Parent2 Special Custody"),
                                   //SiblingName = item.Field<string>("Sibling Name"),
                                   //SiblingAge = item.Field<int>("Sibling Age"),
                                   //SiblingGender = item.Field<int>("Sibling Gender"),
                                   //Contact1Name = item.Field<string>("Contact1 Name"),
                                   //Contact1Phone = item.Field<string>("Contact1 Phone"),
                                   //Contact1Email = item.Field<string>("Contact1 Email"),
                                   //Contact1Address = item.Field<string>("Contact1 Address"),
                                   //Contact1Relationship = item.Field<string>("Contact1 Relationship"),
                                   //Contact2Name = item.Field<string>("Contact2 Name"),
                                   //Contact2Phone = item.Field<string>("Contact2 Phone"),
                                   //Contact2Email = item.Field<string>("Contact2 Email"),
                                   //Contact2Address = item.Field<string>("Contact2 Address"),
                                   //Contact2Relationship = item.Field<string>("Contact2 Relationship"),
                                   //Contact3Name = item.Field<string>("Contact3 Name"),
                                   //Contact3Phone = item.Field<string>("Contact3 Phone"),
                                   //Contact3Email = item.Field<string>("Contact3 Email"),
                                   //Contact3Address = item.Field<string>("Contact3 Address"),
                                   //Contact3Relationship = item.Field<string>("Contact3 Relationship"),
                                   //Contact4Name = item.Field<string>("Contact4 Name"),
                                   //Contact4Phone = item.Field<string>("Contact4 Phone"),
                                   //Contact4Email = item.Field<string>("Contact4 Email"),
                                   //Contact4Address = item.Field<string>("Contact4 Address"),
                                   //Contact4Relationship = item.Field<string>("Contact4 Relationship"),
                                   //BookingId = item.Field<int>("BookingId"),
                                   //DealID = item.Field<string>("DealID"),
                                   //DealTCV = item.Field<decimal>("DealTCV"),
                                   //IsEnabled = item.Field<bool>("IsEnabled"),

                               }).ToList();
            return Childs;
        }

        public Childdetails GetSingleChilddetails(ItemList request)
        {
            int ParamCount = 0;
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[ParamCount] = new SqlParameter("@ChildId", SqlDbType.Int);
            sqlParameters[ParamCount].Value = request.ChildID;
            


            DataSet dsData = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, CommanDataReader.GetSingleChilddetails, sqlParameters);
            Childdetails Childdetail = (from item in dsData.Tables[0].AsEnumerable()
                                         select new Childdetails
                                         {

                                             ChildID = item.Field<int>("ChildID"),
                                             ChildLastName = item.Field<string>("Child Last Name"),
                                             ChildFirstName = item.Field<string>("Child First Name"),
                                             ChildGender = item.Field<int>("Child Gender"),
                                             ChildBirthDate = item.Field<string>("Child Birth Date"),
                                             ChildStatus = item.Field<int>("Child Status"),
                                             ChildAddress = item.Field<string>("Child Address"),
                                             ChildType = item.Field<int>("Child Type"),
                                             Parent1LastName = item.Field<string>("Parent1 Last Name"),
                                             Parent1FirstName = item.Field<string>("Parent1 First Name"),
                                             Parent1Private = item.Field<string>("Parent1 Private"),
                                             Parent1Gender = item.Field<int>("Parent1 Gender"),
                                             Parent1ChildRelation = item.Field<int>("Parent1 Child Relation"),
                                             Parent1Address = item.Field<string>("Parent1 Address"),
                                             Parent1Unit = item.Field<string>("Parent1 Unit"),
                                             Parent1City = item.Field<string>("Parent1 City"),
                                             Parent1Province = item.Field<string>("Parent1 Province"),
                                             Parent1PostalCode = item.Field<string>("Parent1 Postal Code"),
                                             Parent1HomePhone = item.Field<string>("Parent1 Home Phone"),
                                             Parent1WorkPhone = item.Field<string>("Parent1 Work Phone"),
                                             Parent1CellPhone = item.Field<string>("Parent1 Cell Phone"),
                                             Parent1Email = item.Field<string>("Parent1 Email"),
                                             Parent1PrimaryEmail = item.Field<string>("Parent1 Primary Email"),
                                             Parent1Comments = item.Field<string>("Parent1 Comments"),
                                             Parent1SpecialCustody = item.Field<string>("Parent1 Special Custody"),
                                             Parent2LastName = item.Field<string>("Parent2 Last Name"),
                                             Parent2FirstName = item.Field<string>("Parent2 First Name"),
                                             Parent2Private = item.Field<string>("Parent2 Private"),
                                             Parent2Gender = item.Field<int>("Parent2 Gender"),
                                             Parent2ChildRelation = item.Field<int>("Parent2 Child Relation"),
                                             Parent2Address = item.Field<string>("Parent2 Address"),
                                             Parent2Unit = item.Field<string>("Parent2 Unit"),
                                             Parent2City = item.Field<string>("Parent2 City"),
                                             Parent2Province = item.Field<string>("Parent2 Province"),
                                             Parent2PostalCode = item.Field<string>("Parent2 Postal Code"),
                                             Parent2HomePhone = item.Field<string>("Parent2 Home Phone"),
                                             Parent2WorkPhone = item.Field<string>("Parent2 Work Phone"),
                                             Parent2CellPhone = item.Field<string>("Parent2 Cell Phone"),
                                             Parent2Email = item.Field<string>("Parent2 Email"),
                                             Parent2PrimaryEmail = item.Field<string>("Parent2 Primary Email"),
                                             Parent2Comments = item.Field<string>("Parent2 Comments"),
                                             Parent2SpecialCustody = item.Field<string>("Parent2 Special Custody"),
                                             SiblingName = item.Field<string>("Sibling Name"),
                                             SiblingAge = item.Field<int>("Sibling Age"),
                                             SiblingGender = item.Field<int>("Sibling Gender"),
                                             Contact1Name = item.Field<string>("Contact1 Name"),
                                             Contact1Phone = item.Field<string>("Contact1 Phone"),
                                             Contact1Email = item.Field<string>("Contact1 Email"),
                                             Contact1Address = item.Field<string>("Contact1 Address"),
                                             Contact1Relationship = item.Field<int>("Contact1 Relationship")
                                             //Contact2Name = item.Field<string>("Contact2 Name"),
                                             //Contact2Phone = item.Field<string>("Contact2 Phone"),
                                             //Contact2Email = item.Field<string>("Contact2 Email"),
                                             //Contact2Address = item.Field<string>("Contact2 Address"),
                                             //Contact2Relationship = item.Field<string>("Contact2 Relationship"),
                                             //Contact3Name = item.Field<string>("Contact3 Name"),
                                             //Contact3Phone = item.Field<string>("Contact3 Phone"),
                                             //Contact3Email = item.Field<string>("Contact3 Email"),
                                             //Contact3Address = item.Field<string>("Contact3 Address"),
                                             //Contact3Relationship = item.Field<string>("Contact3 Relationship"),
                                             //Contact4Name = item.Field<string>("Contact4 Name"),
                                             //Contact4Phone = item.Field<string>("Contact4 Phone"),
                                             //Contact4Email = item.Field<string>("Contact4 Email"),
                                             //Contact4Address = item.Field<string>("Contact4 Address"),
                                             //Contact4Relationship = item.Field<string>("Contact4 Relationship"),
                                             //BookingId = item.Field<int>("BookingId"),
                                             //DealID = item.Field<string>("DealID"),
                                             //DealTCV = item.Field<decimal>("DealTCV"),
                                             //IsEnabled = item.Field<bool>("IsEnabled"),

                                         }).SingleOrDefault();
            return Childdetail;
        }

        public void UpdateChild(List<ChildDocument> document)
        {
            DataSet dsdocument = new DataSet("dsdocument");
            DataTable dtdocument = new DataTable();
            dtdocument = ToDataTable<ChildDocument>(document, "dtdocument");
            dsdocument.Tables.Add(dtdocument);

            int ParamCount = 0;
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[ParamCount] = new SqlParameter("@document", SqlDbType.VarChar, -1);
            sqlParameters[ParamCount].Value = dsdocument.GetXml(); ParamCount++;
            SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, CommanDataReader.AddDocument, sqlParameters);
         
        }

        //public List<ChildDocument> UpdateChild(Childdetails child, List<ChildDocument> document)
        //{
        //    DataSet dsdocument = new DataSet("dsdocument");
        //    DataTable dtdocument = new DataTable();
        //    dtdocument = ToDataTable<ChildDocument>(document, "dtdocument");
        //    dsdocument.Tables.Add(dtdocument);

        //    int ParamCount = 0;
        //    SqlParameter[] sqlParameters = new SqlParameter[65];
        //    sqlParameters[ParamCount] = new SqlParameter("@ChildID", SqlDbType.Int);
        //    sqlParameters[ParamCount].Value = child.ChildID; ParamCount++;
        //    sqlParameters[ParamCount] = new SqlParameter("@ChildLastName", SqlDbType.VarChar, 50);
        //    sqlParameters[ParamCount].Value = child.ChildLastName; ParamCount++;
        //    sqlParameters[ParamCount] = new SqlParameter("@ChildFirstName", SqlDbType.VarChar, 50);
        //    sqlParameters[ParamCount].Value = child.ChildFirstName; ParamCount++;
        //    sqlParameters[ParamCount] = new SqlParameter("@ChildGender", SqlDbType.Int);
        //    //sqlParameters[ParamCount].Value = child.ChildGender; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@ChildBirthDate", SqlDbType.VarChar, 10);
        //    //sqlParameters[ParamCount].Value = ""; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@ChildStatus", SqlDbType.Int);
        //    //sqlParameters[ParamCount].Value = child.ChildStatus; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@ChildAddress", SqlDbType.VarChar, 100);
        //    //sqlParameters[ParamCount].Value = child.ChildAddress; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@ChildType", SqlDbType.Int);
        //    //sqlParameters[ParamCount].Value = child.ChildType; ParamCount++;


        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1LastName", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1LastName; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1FirstName", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1FirstName; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1Private", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1Private; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1Gender", SqlDbType.Int);
        //    //sqlParameters[ParamCount].Value = child.Parent1Gender; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1ChildRelation", SqlDbType.Int);
        //    //sqlParameters[ParamCount].Value = child.Parent1ChildRelation; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1Address", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1Address; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1Unit", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1Unit; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1City", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1City; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1Province", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1Province; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1PostalCode", SqlDbType.VarChar, 10);
        //    //sqlParameters[ParamCount].Value = child.Parent1PostalCode; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1HomePhone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1HomePhone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1WorkPhone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1WorkPhone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1CellPhone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1CellPhone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1Email", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1Email; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1PrimaryEmail", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1PrimaryEmail; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1Comments", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1Comments; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent1SpecialCustody", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent1SpecialCustody; ParamCount++;


        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2LastName", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2LastName; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2FirstName", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2FirstName; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2Private", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2Private; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2Gender", SqlDbType.Int);
        //    //sqlParameters[ParamCount].Value = child.Parent2Gender; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2ChildRelation", SqlDbType.Int);
        //    //sqlParameters[ParamCount].Value = child.Parent2ChildRelation; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2Address", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2Address; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2Unit", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2Unit; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2City", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2City; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2Province", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2Province; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2PostalCode", SqlDbType.VarChar, 10);
        //    //sqlParameters[ParamCount].Value = child.Parent2PostalCode; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2HomePhone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2HomePhone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2WorkPhone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2WorkPhone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2CellPhone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2CellPhone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2Email", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2Email; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2PrimaryEmail", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2PrimaryEmail; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2Comments", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2Comments; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Parent2SpecialCustody", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Parent2SpecialCustody; ParamCount++;

        //    //sqlParameters[ParamCount] = new SqlParameter("@SiblingName", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.SiblingName; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@SiblingAge", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.SiblingAge; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@SiblingGender", SqlDbType.Int);
        //    //sqlParameters[ParamCount].Value = child.SiblingGender; ParamCount++;

        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact1Name", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact1Name; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact1Phone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact1Phone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact1Email", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact1Email; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact1Address", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact1Address; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact1Relationship", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact1Relationship; ParamCount++;

        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact2Name", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact2Name; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact2Phone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact2Phone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact2Email", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact2Email; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact2Address", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact2Address; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact2Relationship", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact2Relationship; ParamCount++;

        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact3Name", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact3Name; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact3Phone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact3Phone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact3Email", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact3Email; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact3Address", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact3Address; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact3Relationship", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact3Relationship; ParamCount++;


        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact4Name", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact4Name; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact4Phone", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact4Phone; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact4Email", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact4Email; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact4Address", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact4Address; ParamCount++;
        //    //sqlParameters[ParamCount] = new SqlParameter("@Contact4Relationship", SqlDbType.VarChar, 50);
        //    //sqlParameters[ParamCount].Value = child.Contact4Relationship; ParamCount++;

        //    sqlParameters[ParamCount] = new SqlParameter("@document", SqlDbType.VarChar, -1);
        //    sqlParameters[ParamCount].Value = dsdocument.GetXml(); ParamCount++;

        //    DataSet dsData = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, CommanDataReader.UpdateChildInfo, sqlParameters);
        //    List<ChildDocument> childdocument = (from item in dsData.Tables[0].AsEnumerable()
        //                                       select new ChildDocument
        //                                       {
        //                                           DocumentId = item.Field<int>("DocumentId"),
        //                                           DocumentFileName = item.Field<string>("DocumentFileName"),
        //                                           DocumentPath = item.Field<string>("DocumentPath"),
        //                                           EnteredBy = item.Field<string>("EnteredBy"),
        //                                           EnteredOn = item.Field<string>("EnteredOn")
        //                                       }
        //                                      ).ToList();
        //    return childdocument;
        //}
        public DataTable ToDataTableNull<T>(IList<T> data, string datatableName)// T is any generic type
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable(datatableName);
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType.Name.Contains("Nullable") ? typeof(decimal) : prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public DataTable ToDataTable<T>(IList<T> data, string datatableName)// T is any generic type
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable(datatableName);
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
    }
}