using System;

namespace Mall.Infrastructure.Results
{
    public class Result
    { 
        public Boolean IsSuccess { get; set; }

        public String Msg { get; set; }

        protected Result()
        {
        }

        public static Result Fail(String msg)
        {
            return new Result
            {
                IsSuccess = false,
                Msg = msg
            };
        }

        public static Result Success(String msg)
        {
            return new Result
            {
                IsSuccess = true,
                Msg = msg
            };
        }
        
        public static Result Success()
        {
            return Success(string.Empty);
        }
    }


    public class Result<T> : Result
    {
        /// <summary>数据
        /// </summary>
        public T Data { get; set; }

        private Result() { }

        /// <summary>失败
        /// </summary>
        /// <param name="msg">定义失败信息</param>
        /// <returns></returns>
        public new static Result<T> Fail(String msg)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Msg = msg
            };
        }
        /// <summary>失败 
        /// </summary>
        /// <param name="data">要返回的数据泛型</param>
        /// <param name="msg">定义失败信息</param>
        /// <returns></returns>
        public static Result<T> Fail(T data, String msg)
        {
            return new Result<T>
            {
                IsSuccess = false,
                Msg = msg,
                Data = data
            };
        }

        /// <summary>成功 
        /// </summary>
        /// <param name="data">要返回的数据泛型</param>
        /// <param name="msg">可定义成功信息</param>
        /// <returns></returns>
        public static Result<T> Success(T data, String msg)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Msg = msg,
                Data = data
            };
        }

        /// <summary>成功 
        /// </summary>
        /// <param name="data">要返回的数据泛型</param>
        /// <returns></returns>
        public static Result<T> Success(T data)
        {
            return Success(data, string.Empty);
        }
    }
}
