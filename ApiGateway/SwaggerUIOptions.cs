namespace ApiGateway
{
    public class SwaggerUIOptionsSettings
    {
        public List<SwaggerEndpoint> Endpoints { get; set; } = new();
    }

    public class SwaggerEndpoint
    {
        public string Url { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
