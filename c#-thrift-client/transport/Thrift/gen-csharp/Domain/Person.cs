/**
 * Autogenerated by Thrift Compiler (0.9.3)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Domain
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Person : TBase
  {
    private int _personID;
    private string _firstName;
    private string _lastName;

    public int PersonID
    {
      get
      {
        return _personID;
      }
      set
      {
        __isset.personID = true;
        this._personID = value;
      }
    }

    public string FirstName
    {
      get
      {
        return _firstName;
      }
      set
      {
        __isset.firstName = true;
        this._firstName = value;
      }
    }

    public string LastName
    {
      get
      {
        return _lastName;
      }
      set
      {
        __isset.lastName = true;
        this._lastName = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool personID;
      public bool firstName;
      public bool lastName;
    }

    public Person() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.I32) {
                PersonID = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                FirstName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                LastName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("Person");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.personID) {
          field.Name = "personID";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(PersonID);
          oprot.WriteFieldEnd();
        }
        if (FirstName != null && __isset.firstName) {
          field.Name = "firstName";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(FirstName);
          oprot.WriteFieldEnd();
        }
        if (LastName != null && __isset.lastName) {
          field.Name = "lastName";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(LastName);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("Person(");
      bool __first = true;
      if (__isset.personID) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("PersonID: ");
        __sb.Append(PersonID);
      }
      if (FirstName != null && __isset.firstName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FirstName: ");
        __sb.Append(FirstName);
      }
      if (LastName != null && __isset.lastName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LastName: ");
        __sb.Append(LastName);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
