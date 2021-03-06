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
  public partial class Employee : TBase
  {
    private int _employeeID;
    private string _firstName;
    private string _lastName;
    private string _username;
    private string _password;
    private string _office;

    public int EmployeeID
    {
      get
      {
        return _employeeID;
      }
      set
      {
        __isset.employeeID = true;
        this._employeeID = value;
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

    public string Username
    {
      get
      {
        return _username;
      }
      set
      {
        __isset.username = true;
        this._username = value;
      }
    }

    public string Password
    {
      get
      {
        return _password;
      }
      set
      {
        __isset.password = true;
        this._password = value;
      }
    }

    public string Office
    {
      get
      {
        return _office;
      }
      set
      {
        __isset.office = true;
        this._office = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool employeeID;
      public bool firstName;
      public bool lastName;
      public bool username;
      public bool password;
      public bool office;
    }

    public Employee() {
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
                EmployeeID = iprot.ReadI32();
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
            case 4:
              if (field.Type == TType.String) {
                Username = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.String) {
                Password = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.String) {
                Office = iprot.ReadString();
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
        TStruct struc = new TStruct("Employee");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.employeeID) {
          field.Name = "employeeID";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(EmployeeID);
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
        if (Username != null && __isset.username) {
          field.Name = "username";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Username);
          oprot.WriteFieldEnd();
        }
        if (Password != null && __isset.password) {
          field.Name = "password";
          field.Type = TType.String;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Password);
          oprot.WriteFieldEnd();
        }
        if (Office != null && __isset.office) {
          field.Name = "office";
          field.Type = TType.String;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Office);
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
      StringBuilder __sb = new StringBuilder("Employee(");
      bool __first = true;
      if (__isset.employeeID) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("EmployeeID: ");
        __sb.Append(EmployeeID);
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
      if (Username != null && __isset.username) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Username: ");
        __sb.Append(Username);
      }
      if (Password != null && __isset.password) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Password: ");
        __sb.Append(Password);
      }
      if (Office != null && __isset.office) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Office: ");
        __sb.Append(Office);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
