﻿using Services.Contracts;
using System.Text.Json;

namespace Services.ResultModels
{
    public class DecisionModel<T>
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public T Result { get; set; }
        private readonly ILogService _log;

        public DecisionModel(T result, int type, string service, ILogService log)
        {
            _log = log;

            if (type == 1) // getAll
            {
                Message = result == null ? "No data has been entered yet." : "Success";
                StatusCode = 200;
                Result = result;
            }
            else if (type == 2) //get
            {
                Message = result == null ? "No data was found for the Id you specified!" : "Success";
                StatusCode = result == null ? 400 : 200;
                Result = result;
            }
            else if (type == 3) //create
            {
                Message = result == null ? "Do not enter missing data!" : "Success";
                StatusCode = result == null ? 400 : 200;
                Result = result;

                _log.AppendTextToFileAsync($"{service}Created.txt", JsonSerializer.Serialize(this));
            }
            else if (type == 4) //update
            {
                Message = result == null ? "Do not enter missing data!" : "Success";
                StatusCode = result == null ? 400 : 200;
                Result = result;

                _log.AppendTextToFileAsync($"{service}Updated.txt", JsonSerializer.Serialize(this));
            }
            else if (type == 5) //delete
            {
                Message = result == null ? "The model you want to delete could not be found!" : "Success";
                StatusCode = result == null ? 400 : 200;
                Result = result;

                _log.AppendTextToFileAsync($"{service}Deleted.txt", JsonSerializer.Serialize(this));
            }
        }
    }
}