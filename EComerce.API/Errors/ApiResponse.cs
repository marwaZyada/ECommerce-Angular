namespace EComerce.API.Errors
{
    public class ApiResponse
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
      

        public ApiResponse( int statusCode, string? message = null)
        {
          
            StatusCode = statusCode;
            Message = message ?? GetMessage(StatusCode);
        }
        private string GetMessage(int statusCode)
        {
            var message = statusCode switch
            {
                404 => "Not Found",
                400=>"Bad Request",
                200=>"Done",
                401=>"UnAuthorized",
                500=>"Server Error",
                _=>null


            };

            return message;
        }
    }
}
