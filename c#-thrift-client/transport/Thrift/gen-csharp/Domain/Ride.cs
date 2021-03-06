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
  public partial class Ride : TBase
  {
    private int _rideID;
    private string _destination;
    private string _date;
    private string _hour;
    private int _nrSeats;

    public int RideID
    {
      get
      {
        return _rideID;
      }
      set
      {
        __isset.rideID = true;
        this._rideID = value;
      }
    }

    public string Destination
    {
      get
      {
        return _destination;
      }
      set
      {
        __isset.destination = true;
        this._destination = value;
      }
    }

    public string Date
    {
      get
      {
        return _date;
      }
      set
      {
        __isset.date = true;
        this._date = value;
      }
    }

    public string Hour
    {
      get
      {
        return _hour;
      }
      set
      {
        __isset.hour = true;
        this._hour = value;
      }
    }

    public int NrSeats
    {
      get
      {
        return _nrSeats;
      }
      set
      {
        __isset.nrSeats = true;
        this._nrSeats = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool rideID;
      public bool destination;
      public bool date;
      public bool hour;
      public bool nrSeats;
    }

    public Ride() {
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
                RideID = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Destination = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Date = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                Hour = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.I32) {
                NrSeats = iprot.ReadI32();
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
        TStruct struc = new TStruct("Ride");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.rideID) {
          field.Name = "rideID";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(RideID);
          oprot.WriteFieldEnd();
        }
        if (Destination != null && __isset.destination) {
          field.Name = "destination";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Destination);
          oprot.WriteFieldEnd();
        }
        if (Date != null && __isset.date) {
          field.Name = "date";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Date);
          oprot.WriteFieldEnd();
        }
        if (Hour != null && __isset.hour) {
          field.Name = "hour";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Hour);
          oprot.WriteFieldEnd();
        }
        if (__isset.nrSeats) {
          field.Name = "nrSeats";
          field.Type = TType.I32;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(NrSeats);
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
      StringBuilder __sb = new StringBuilder("Ride(");
      bool __first = true;
      if (__isset.rideID) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("RideID: ");
        __sb.Append(RideID);
      }
      if (Destination != null && __isset.destination) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Destination: ");
        __sb.Append(Destination);
      }
      if (Date != null && __isset.date) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Date: ");
        __sb.Append(Date);
      }
      if (Hour != null && __isset.hour) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Hour: ");
        __sb.Append(Hour);
      }
      if (__isset.nrSeats) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("NrSeats: ");
        __sb.Append(NrSeats);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
