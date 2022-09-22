using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
    

public static  class SQLFrame
{
   // 链接对象
   private static SqliteConnection Con;
   // 指令
   private static SqliteCommand command;
   // 阅读器
   private static SqliteDataReader reader;
   
   // 打开数据库
   public static void DataBaseOpen(string BaseName)
   {
      // 判断是否后缀是否加了.sqlite
      if (!BaseName.Contains(".sqlite"))
      {
         BaseName += ".sqlite";
      }
      Debug.Log(BaseName);
      
      BaseName = "Data Source =" + Application.streamingAssetsPath + "/" + BaseName;
      
      Con = new SqliteConnection(BaseName);
      Con.Open();
      command = Con.CreateCommand();
      
      if (!IsConSucess())
      {
         throw new Exception("数据库未连接成功");
      }
      else
      {
         Debug.Log("链接成功");
      }
      
   }

   private static bool IsConSucess()
   {
      if (Con == null || command == null)
         return false;
      return true;
   }
   
   // 对数据库进行修改
   public static int SerachDase(string query)
   {
      command.CommandText = query;
      return command.ExecuteNonQuery();
   }
   // 对数据库进行查询（单个查询）
   public static object InquireNoce(string query)
   {
      command.CommandText = query;
      object val = command.ExecuteScalar();
      return val;
   }
   // 对数据库查询（多个）
   public static List<ArrayList> InquireMore(string query)
   {
      command.CommandText = query;
    
      reader = command.ExecuteReader();
      List<ArrayList> list = new List<ArrayList>();
      while (reader.Read())
      {
         ArrayList arrayList = new ArrayList();
         for (int i = 0; i < reader.FieldCount; ++i)
         {
            arrayList.Add(reader.GetValue(i));
         }
         list.Add(arrayList);
      }
      reader.Close();
      return list;
   }
   
   // 断开数据库链接
   public static void SQLClose()
   {
      Debug.Log("关闭数据库");
      if (reader != null)
      {
         reader.Close();
      }

      if (command != null)
      {
         command.Dispose();
      }

      if (Con != null)
      {
         Con.Close();
      }
   }
}
