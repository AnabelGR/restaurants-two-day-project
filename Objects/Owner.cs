// using System.Collections.Generic;
// using System.Data.SqlClient;
// using System;
//
// namespace RestuarantProject
// {
//   public class Owner
//   {
//     private static string _ownerName = "admin";
//     private static string _ownerPassword = "pa55w0rd";
//     private string _userNameEntry;
//     private string _userPasswordEntry;
//     private static bool _status;
//
//     public Owner(string userNameEntry, string userPasswordEntry)
//     {
//       _userNameEntry = userNameEntry;
//       _userPasswordEntry = userPasswordEntry;
//     }
//     public static bool GetStatus()
//     {
//       return _status;
//     }
//     public static void SetStatus(bool update)
//     {
//       _status = update;
//     }
//     public string GetNameEntry()
//     {
//       return _userNameEntry;
//     }
//     public string GetPasswordEntry()
//     {
//       return _userPasswordEntry;
//     }
//     public bool CheckPassword()
//     {
//       if (_userPasswordEntry == _adminPassword)
//       {
//         return true;
//       }
//       else
//       {
//         return false;
//       }
//     }
//   }
// }
