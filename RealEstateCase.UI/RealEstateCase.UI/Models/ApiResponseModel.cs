﻿namespace RealEstateCase.UI.Models
{
    public class ApiResponseModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
    }

}
