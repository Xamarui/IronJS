﻿namespace IronJS.Native

open System
open IronJS
open IronJS.DescriptorAttrs

(*
//  This module implements the javascript String objects functions and properties.
//
//  DONE:
//  15.5.1.1 String ( [ value ] )
//  15.5.2.1 new String ( [ value ] )
//  15.5.3.1 String.prototype
//  15.5.3.2 String.fromCharCode ( [ char0 [ , char1 [ , … ] ] ] )
//  15.5.4.1 String.prototype.constructor
//  15.5.4.2 String.prototype.toString ( )
//  15.5.4.3 String.prototype.valueOf ( )
//  15.5.4.4 String.prototype.charAt (pos)
//  15.5.4.5 String.prototype.charCodeAt (pos)
//  15.5.4.6 String.prototype.concat ( [ string1 [ , string2 [ , … ] ] ] )
//  15.5.4.7 String.prototype.indexOf (searchString, position)
//  15.5.4.8 String.prototype.lastIndexOf (searchString, position)
//  15.5.4.9 String.prototype.localeCompare (that)
//  15.5.4.13 String.prototype.slice (start, end)
//  15.5.4.15 String.prototype.substring (start, end)
//  15.5.4.16 String.prototype.toLowerCase ( )
//  15.5.4.17 String.prototype.toLocaleLowerCase ( )
//  15.5.4.18 String.prototype.toUpperCase ( )
//  15.5.4.19 String.prototype.toLocaleUpperCase ( )
//
//  NOT DONE:
//  15.5.4.10 String.prototype.match (regexp)
//  15.5.4.11 String.prototype.replace (searchValue, replaceValue) - REGEXP/FUNCTION MISSING
//  15.5.4.12 String.prototype.search (regexp) - REGEXP MISSING
//  15.5.4.14 String.prototype.split (separator, limit) - REGEXP MISSING
*)

module String =

  //----------------------------------------------------------------------------
  let internal constructor' (ctor:FunctionObject) (this:CommonObject) (value:BoxedValue) =
    let value = TypeConverter.ToString value
    match this with
    | null -> ctor.Env.NewString(value) |> BV.Box
    | _ -> value |> BV.Box
    
  //----------------------------------------------------------------------------
  let internal fromCharCode (args:BoxedValue array) =
    let buffer = Text.StringBuilder(args.Length)

    for i = 0 to args.Length-1 do
      buffer.Append(TypeConverter.ToUInt16 args.[i] |> char) |> ignore

    buffer.ToString()

  //----------------------------------------------------------------------------
  let internal toString (func:FunctionObject) (this:CommonObject) =
    this |> Utils.mustBe Classes.String func.Env
    this |> Utils.ValueObject.getValue
    
  //----------------------------------------------------------------------------
  let internal valueOf (func:FunctionObject) (this:CommonObject) = 
    toString func this
    
  //----------------------------------------------------------------------------
  let internal charAt (this:CommonObject) (pos:double) =
    let value = TypeConverter.ToString this
    let index = TypeConverter.ToInt32 pos
    if index < 0 || index >= value.Length then "" else value.[index] |> string

  //----------------------------------------------------------------------------
  let internal charCodeAt (this:CommonObject) (pos:double) =
    let value = TypeConverter.ToString this
    let index = TypeConverter.ToInt32 pos
    if index < 0 || index >= value.Length then nan else value.[index] |> double
    
  //----------------------------------------------------------------------------
  let internal concat (this:CommonObject) (args:BoxedValue array) =
    let buffer = new Text.StringBuilder(TypeConverter.ToString this)
    let toString (x:BoxedValue) = buffer.Append(TypeConverter.ToString x)
    args |> Array.iter (toString >> ignore)
    buffer.ToString()
    
  //----------------------------------------------------------------------------
  let internal indexOf (this:CommonObject) (subString:string) (index:double) =
    let value = this |> TypeConverter.ToString
    let index = index |> TypeConverter.ToInt32
    let index = Math.Min(Math.Max(index, 0), value.Length);
    value.IndexOf(subString, index, StringComparison.Ordinal) |> double
    
  //----------------------------------------------------------------------------
  let internal lastIndexOf (this:CommonObject) (subString:string) (index:double) =
    let value = this |> TypeConverter.ToString

    let index = 
      if Double.IsNaN index 
        then Int32.MaxValue 
        else TypeConverter.ToInteger index

    let index = Math.Min(index, value.Length-1)
    let index = Math.Min(index + subString.Length-1, value.Length-1)
    
    let index = 
      if index < 0 
        then  if value = "" && subString = "" then 0 else -1
        else value.LastIndexOf(subString, index, StringComparison.Ordinal)

    index |> double
      
  //----------------------------------------------------------------------------
  let internal localeCompare (this:CommonObject) (that:CommonObject) =
    let value = this |> TypeConverter.ToString
    let that = this |> TypeConverter.ToString
    String.Compare(value, that) |> double
    
  //----------------------------------------------------------------------------
  let internal match' (this:CommonObject) (regexp:CommonObject) =
    failwith "Not implemented"
    false
    
  //----------------------------------------------------------------------------
  let internal replace (this:CommonObject) (search:BoxedValue) (replace:BoxedValue) =
    let value = this |> TypeConverter.ToString

    //replace(regex, *)
    if search.Tag >= TypeTags.Object then 
      failwith "Not implemented"
      
    //replace(string, *)
    else
      let search = search |> TypeConverter.ToString
      
      if replace.Tag >= TypeTags.Function then 
        //replace(string, function)
        failwith "Not implemented"

      else
        //replace(string, string)
        let replace = replace |> TypeConverter.ToString
        let startIndex = value.IndexOf search
        if startIndex = -1 then value
        else
          let endIndex = startIndex + search.Length
          let bufferSize = value.Length + (replace.Length - search.Length)
          let buffer = new Text.StringBuilder(bufferSize);
          buffer.Append(value, 0, startIndex) |> ignore
          buffer.Append(replace) |> ignore
          buffer.Append(value, endIndex, value.Length - endIndex) |> ignore
          buffer.ToString()
          
  //----------------------------------------------------------------------------
  let internal search (this:CommonObject) (search:BoxedValue) =
    let value = this |> TypeConverter.ToString

    //search(regex)
    if search.Tag >= TypeTags.Object then 
      failwith "Not implemented"
      
    //search(string)
    else
      let search = search |> TypeConverter.ToString
      value.IndexOf(search, StringComparison.Ordinal) |> double
      
  //----------------------------------------------------------------------------
  let internal slice (this:CommonObject) (start:double) (end':BoxedValue) =
    let value = this  |> TypeConverter.ToString
    let start = start |> TypeConverter.ToInteger

    let isUndefined = end'.Tag |> Utils.Box.isUndefined  
    let end' = if isUndefined then start else value.Length

    let start = Math.Min(Math.Max(start, 0), value.Length)
    let end'  = Math.Min(Math.Max(end', 0), value.Length)

    if end' <= start then "" else value.Substring(start, end' - start)
    
  //----------------------------------------------------------------------------
  let internal split (f:FunctionObject) (this:CommonObject) (sep:BoxedValue) (limit:BoxedValue) =
    let value = this |> TypeConverter.ToString

    if sep |> Utils.Box.isRegExp then
      failwith "Not implemented"

    else
      let separator =
        if sep.Tag |> Utils.Box.isUndefined
          then "" else sep |> TypeConverter.ToString

      let limit =
        if limit.Tag |> Utils.Box.isUndefined
          then UInt32.MaxValue else limit |> TypeConverter.ToUInt32
          
      if separator |> String.IsNullOrEmpty then
        let length = Math.Min(uint32 value.Length, limit)
        let array = f.Env.NewArray(length) :?> ArrayObject
        for i = 0 to value.Length-1 do
          if uint32 i < limit then
            let descr = &array.Dense.[i]
            descr.Value.Clr <- string value.[i]
            descr.Value.Tag <- TypeTags.String
            descr.HasValue <- true
        array :> CommonObject

      else
        let parts = value.Split([|separator|], StringSplitOptions.None)
        let length = Math.Min(uint32 parts.Length, limit)
        let array = f.Env.NewArray(length) :?> ArrayObject
        for i = 0 to parts.Length-1 do
          if uint32 i < limit then
            let descr = &array.Dense.[i]
            descr.Value.Clr <- parts.[i]
            descr.Value.Tag <- TypeTags.String
            descr.HasValue <- true
        array :> CommonObject
        
  //----------------------------------------------------------------------------
  let internal substring (this:CommonObject) (start:double) (end':double) =
    let value = this |> TypeConverter.ToString

    let start = start |> TypeConverter.ToInt32
    let start = if start < 0 then Math.Max(start + value.Length, 0) else start

    let end' = end' |> TypeConverter.ToInt32
    let end' = Math.Max(Math.Min(end', value.Length-start), 0)

    if end' <= 0 then "" else value.Substring(start, end')
    
  //----------------------------------------------------------------------------
  let internal toLowerCase (this:CommonObject) =
    let value = this |> TypeConverter.ToString
    value.ToLowerInvariant()
    
  //----------------------------------------------------------------------------
  let internal toLocaleLowerCase (this:CommonObject) =
    let value = this |> TypeConverter.ToString
    value.ToLower()
    
  //----------------------------------------------------------------------------
  let internal toUpperCase (this:CommonObject) =
    let value = this |> TypeConverter.ToString
    value.ToUpperInvariant()
    
  //----------------------------------------------------------------------------
  let internal toLocaleUpperCase (this:CommonObject) =
    let value = this |> TypeConverter.ToString
    value.ToUpper()
        
  //----------------------------------------------------------------------------
  let createPrototype (env:Environment) objPrototype =
    let prototype = env.NewString()
    prototype.Put("length", 0.0)
    prototype.Class <- Classes.String
    prototype.Prototype <- objPrototype
    prototype
    
  //----------------------------------------------------------------------------
  let setupConstructor (env:Environment) =
    let ctor = new Func<FunctionObject, CommonObject, BoxedValue, BoxedValue>(constructor')
    let ctor = Utils.createHostFunction env ctor

    let fromCharCode = new Func<BoxedValue array, string>(fromCharCode)
    let fromCharCode = Utils.createHostFunction env fromCharCode
    ctor.Put("fromCharCode", fromCharCode, DontEnum)

    ctor.ConstructorMode <- ConstructorModes.Host
    ctor.Put("prototype", env.Prototypes.String, Immutable)

    env.Globals.Put("String", ctor)
    env.Constructors <- {env.Constructors with String=ctor}
    
  //----------------------------------------------------------------------------
  let setupPrototype (env:Environment) =
    let proto = env.Prototypes.String;

    proto.Put("constructor", env.Constructors.String, DontEnum) // 15.6.4.1

    let toString = new Func<FunctionObject, CommonObject, BoxedValue>(toString)
    let toString = Utils.createHostFunction env toString
    proto.Put("toString", toString, DontEnum)

    let valueOf = new Func<FunctionObject, CommonObject, BoxedValue>(valueOf)
    let valueOf = Utils.createHostFunction env valueOf
    proto.Put("valueOf", valueOf, DontEnum)

    let charAt = new Func<CommonObject, double, string>(charAt)
    let charAt = Utils.createHostFunction env charAt
    proto.Put("charAt", charAt, DontEnum)

    let charCodeAt = new Func<CommonObject, double, double>(charCodeAt)
    let charCodeAt = Utils.createHostFunction env charCodeAt
    proto.Put("charCodeAt", charCodeAt, DontEnum)

    let concat = new Func<CommonObject, BoxedValue array, string>(concat)
    let concat = Utils.createHostFunction env concat
    proto.Put("concat", concat, DontEnum)

    let indexOf = new Func<CommonObject, string, double, double>(indexOf)
    let indexOf = Utils.createHostFunction env indexOf
    proto.Put("indexOf", indexOf, DontEnum)

    let lastIndexOf = new Func<CommonObject, string, double, double>(lastIndexOf)
    let lastIndexOf = Utils.createHostFunction env lastIndexOf
    proto.Put("lastIndexOf", lastIndexOf, DontEnum)

    let localeCompare = new Func<CommonObject, CommonObject, double>(localeCompare)
    let localeCompare = Utils.createHostFunction env localeCompare
    proto.Put("localeCompare", localeCompare, DontEnum)

    let match' = new Func<CommonObject, CommonObject, bool>(match')
    let match' = Utils.createHostFunction env match'
    proto.Put("match", match', DontEnum)

    let replace = new Func<CommonObject, BoxedValue, BoxedValue, string>(replace)
    let replace = Utils.createHostFunction env replace
    proto.Put("replace", replace, DontEnum)

    let search = new Func<CommonObject, BoxedValue, double>(search)
    let search = Utils.createHostFunction env search
    proto.Put("search", search, DontEnum)

    let slice = new Func<CommonObject, double, BoxedValue, string>(slice)
    let slice = Utils.createHostFunction env slice
    proto.Put("slice", slice, DontEnum)

    let split = new Func<FunctionObject, CommonObject, BoxedValue, BoxedValue, CommonObject>(split)
    let split = Utils.createHostFunction env split
    proto.Put("split", split, DontEnum)

    let substring = new Func<CommonObject, double, double, string>(substring)
    let substring = Utils.createHostFunction env substring
    proto.Put("substring", substring, DontEnum)

    let toLowerCase = new Func<CommonObject, string>(toLowerCase)
    let toLowerCase = Utils.createHostFunction env toLowerCase
    proto.Put("toLowerCase", toLowerCase, DontEnum)
    
    let toLocaleLowerCase = new Func<CommonObject, string>(toLocaleLowerCase)
    let toLocaleLowerCase = Utils.createHostFunction env toLocaleLowerCase
    proto.Put("toLocaleLowerCase", toLocaleLowerCase, DontEnum)

    let toUpperCase = new Func<CommonObject, string>(toUpperCase)
    let toUpperCase = Utils.createHostFunction env toUpperCase
    proto.Put("toUpperCase", toUpperCase, DontEnum)

    let toLocaleUpperCase = new Func<CommonObject, string>(toLocaleUpperCase)
    let toLocaleUpperCase = Utils.createHostFunction env toLocaleUpperCase
    proto.Put("toLocaleUpperCase", toLocaleUpperCase, DontEnum)
