using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		#region ObjectOps
		public static string ProductAdded = "Product successfully added.";
		public static string ProductDeleted = "Product successfully deleted.";
		public static string ProductUpdated = "Product successfully updated.";

		public static string CategoryAdded = "Category successfully added.";
		public static string CategoryDeleted = "Category successfully deleted.";
		public static string CategoryUpdated = "Category successfully updated."; 
		#endregion

		#region LoginOps
		public static string UserNotFound = "User not found.";
		public static string PasswordError = "The password is incorrect.";
		public static string SuccesfulLogin = "Sign-in confirmed.";
		public static string UserAlreadyExists = "An account already exists with that login email.";
		public static string UserRegistered = "You are succesfull registered.";
		public static string AccessTokenCreated = "You access token is working.";
		#endregion

		public static string AuthorizationDenied = "You are not authorized";
	}
}
