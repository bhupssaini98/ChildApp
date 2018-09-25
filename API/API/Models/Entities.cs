using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Entities
    {
    }
    public class MyResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
    public class SelectList
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public class ItemList
    {
        public string Id { get; set; }
        public int   ChildID { get; set; }
        public string UpdatedBy { get; set; }
        public string Remarks { get; set; }
    }
    public class SearchFilter
    {
        public List<SelectList> Gender { get; set; }
        public List<SelectList> Type { get; set; }
        public List<SelectList> ChildRelation { get; set; }
        public List<SelectList> Status { get; set; }
    }


    public class ResponseMessage
    {
        public int ID { get; set; }
        public string Message { get; set; }
    }
    public class RequestParams
    {
  
        public int ChildID { get; set; }
        public string ChildFirstName { get; set; }
        public string ChildLastName { get; set; }
 
    }
   
  
    public class ChildDocument
    {
        public int DocumentId { get; set; }
        public int ChildId { get; set;}
        public string Document { get; set; }
        public int FileSize { get; set; }
        public string EnteredBy { get; set; }
        public string EnteredOn { get; set; }
    }

    public class Childdetails
    {
public int ChildID { get; set; }
public string ChildLastName { get; set; }
public string ChildFirstName { get; set; }
        public int ChildGender { get; set; }
        public string ChildBirthDate { get; set; }
        public int ChildStatus { get; set; }
        public string ChildAddress { get; set; }
        public int ChildType { get; set; }
        public string Parent1LastName { get; set; }
        public string Parent1FirstName { get; set; }
        public string Parent1Private { get; set; }
        public int Parent1Gender { get; set; }
        public int Parent1ChildRelation { get; set; }
        public string Parent1Address { get; set; }
        public string Parent1Unit { get; set; }
        public string Parent1City { get; set; }
        public string Parent1Province { get; set; }
        public string Parent1PostalCode { get; set; }
        public string Parent1HomePhone { get; set; }
        public string Parent1WorkPhone { get; set; }
        public string Parent1CellPhone { get; set; }
        public string Parent1Email { get; set; }
        public string Parent1PrimaryEmail { get; set; }
        public string Parent1Comments { get; set; }
        public string Parent1SpecialCustody { get; set; }
        public string Parent2LastName { get; set; }
        public string Parent2FirstName { get; set; }
        public string Parent2Private { get; set; }
        public int Parent2Gender { get; set; }
        public int Parent2ChildRelation { get; set; }
        public string Parent2Address { get; set; }
        public string Parent2Unit { get; set; }
        public string Parent2City { get; set; }
        public string Parent2Province { get; set; }
        public string Parent2PostalCode { get; set; }
        public string Parent2HomePhone { get; set; }
        public string Parent2WorkPhone { get; set; }
        public string Parent2CellPhone { get; set; }
        public string Parent2Email { get; set; }
        public string Parent2PrimaryEmail { get; set; }
        public string Parent2Comments { get; set; }
        public string Parent2SpecialCustody { get; set; }
        public string SiblingName { get; set; }
        public int SiblingAge { get; set; }
        public int SiblingGender { get; set; }
        public string Contact1Name { get; set; }
        public string Contact1Phone { get; set; }
        public string Contact1Email { get; set; }
        public string Contact1Address { get; set; }
        public int Contact1Relationship { get; set; }
        public string Contact2Name { get; set; }
        public string Contact2Phone { get; set; }
        public string Contact2Email { get; set; }
        public string Contact2Address { get; set; }
        public int Contact2Relationship { get; set; }
        public string Contact3Name { get; set; }
        public string Contact3Phone { get; set; }
        public int Contact3Email { get; set; }
        public string Contact3Address { get; set; }
        public string Contact3Relationship { get; set; }
        public string Contact4Name { get; set; }
        public string Contact4Phone { get; set; }
        public int Contact4Email { get; set; }
        public string Contact4Address { get; set; }
        public string Contact4Relationship { get; set; }

    }

    }