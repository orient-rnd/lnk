using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BomBiEn.AppServices.Lnk.Models
{
    public class JsonResultData
    {
        #region .ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonResultData" /> class.
        /// </summary>
        public JsonResultData()
        {
            Success = true;
            Messages = new string[0];
            FieldErrors = new JsonResultDataFieldError[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonResultData" /> class.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        public JsonResultData(ModelStateDictionary modelState)
            : this()
        {
            AddModelState(modelState);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="JsonResultData" /> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        public string[] Messages { get; set; }

        /// <summary>
        /// Gets or sets the field errors.
        /// </summary>
        public JsonResultDataFieldError[] FieldErrors { get; set; }

        /// <summary>
        /// Gets or sets the redirect URL.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [reload page].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [reload page]; otherwise, <c>false</c>.
        /// </value>
        public bool ReloadPage { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Adds the state of the model.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        /// <returns></returns>
        public void AddModelState(ModelStateDictionary modelState)
        {
            foreach (var keyValue in modelState)
            {
                foreach (var error in keyValue.Value.Errors)
                {
                    AddFieldError(keyValue.Key, error.ErrorMessage);
                }
            }
        }

        /// <summary>
        /// Adds the field error.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public void AddFieldError(string fieldName, string message)
        {
            Success = false;
            FieldErrors = FieldErrors.Concat(new[] { new JsonResultDataFieldError() { FieldName = fieldName, ErrorMessage = message } }).ToArray();
        }

        /// <summary>
        /// Adds the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public void AddMessage(string message)
        {
            Messages = Messages.Concat(new[] { message }).ToArray();
        }

        /// <summary>
        /// Adds the error message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <returns></returns>
        public void AddErrorMessage(string errorMessage)
        {
            Messages = Messages.Concat(new[] { errorMessage }).ToArray();
            Success = false;
        }

        /// <summary>
        /// Adds the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public void AddException(Exception exception)
        {
            AddErrorMessage(exception.Message);
        }

        #endregion

        public JsonResultData RunWithTry(Action<JsonResultData> runMethod)
        {
            try
            {
                runMethod?.Invoke(this);

            }
            catch (Exception ex)
            {
                AddException(ex);
            }

            return this;
        }
    }
}