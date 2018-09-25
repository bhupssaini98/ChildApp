export class SelectList {
    Value: string; Text: string;
}
export class ItemList {
    Id: string;
    ChildID: number;
    UpdatedBy: string;
    Remarks: string;
}
export class SearchFilter {
    Gender: SelectList[];
    Type: SelectList[];
    ChildRelation: SelectList[];
    Status: SelectList[];
}
export class ChildDetails {
ChildID: number;
ChildLastName: string;
ChildFirstName: string;
ChildGender: number;
ChildBirthDate: string;
ChildStatus: number;
ChildAddress: string;
ChildType: number;
Parent1LastName: string;
Parent1FirstName: string;
Parent1Private: string;
Parent1Gender: number;
Parent1ChildRelation: number;
Parent1Address: string;
Parent1Unit: string;
Parent1City: string;
Parent1Province: string;
Parent1PostalCode: string;
Parent1HomePhone: string;
Parent1WorkPhone: string;
Parent1CellPhone: string;
Parent1Email: string;
Parent1PrimaryEmail: string;
Parent1Comments: string;
Parent1SpecialCustody: string;
Parent2LastName: string;
Parent2FirstName: string;
Parent2Private: string;
Parent2Gender: number;
Parent2ChildRelation: number;
Parent2Address: string;
Parent2Unit: string;
Parent2City: string;
Parent2Province: string;
Parent2PostalCode: string;
Parent2HomePhone: string;
Parent2WorkPhone: string;
Parent2CellPhone: string;
Parent2Email: string;
Parent2PrimaryEmail: string;
Parent2Comments: string;
Parent2SpecialCustody: string;
SiblingName: string;
SiblingAge: number;
SiblingGender: number;
Contact1Name: string;
Contact1Phone: string;
Contact1Email: string;
Contact1Address: string;
  Contact1Relationship: number;
Contact2Name: string;
Contact2Phone: string;
Contact2Email: string;
Contact2Address: string;
  Contact2Relationship: number;
Contact3Name: string;
Contact3Phone: string;
Contact3Email: string;
Contact3Address: string;
  Contact3Relationship: number;
Contact4Name: string;
Contact4Phone: string;
Contact4Email: string;
Contact4Address: string;
  Contact4Relationship: number;

}

export class ResponseMessage {
    ID: number;
    Message: string;
}
export class RequestParams {
    ChildID: number;
    ChildFirstName: string;
    ChildLastName: string;
}
export class dealdocument {
    DocumentId: number;
    ChildID: number;
    Document: string;
    FileSize: number;
    EnteredBy: string;
  EnteredOn: string;
}
