﻿using BlazorComponents.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorComponents.Client.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _http;

        public AuthorService(HttpClient http)
        {
            _http = http;
        }

        //public async Task<IEnumerable<AuthorDto>> GetAll(int skip, int take)
        //{
        //    try
        //    {
        //        var response = await _http.GetAsync($"api/Author?skip={skip}&take={take}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        //            {
        //                return Enumerable.Empty<AuthorDto>();
        //            }

        //            return await response.Content.ReadFromJsonAsync<IEnumerable<AuthorDto>>();
        //        }
        //        else
        //        {
        //            var message = await response.Content.ReadAsStringAsync();
        //            throw new Exception($"Http status code: {response.StatusCode} message: {message}");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public async Task<AuthorDataResult> GetAll(int skip, int take)
        {
            try
            {
                var response = await _http.GetAsync($"api/Author?skip={skip}&take={take}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        AuthorDataResult result = new AuthorDataResult();
                        return result;
                    }

                    //return await response.Content.ReadFromJsonAsync<AuthorDataResult>();
                    return await response.Content.ReadFromJsonAsync<AuthorDataResult>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Task<AuthorDto> GetAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> GetAuthorByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorDto>> Search(string firstName)
        {
            throw new NotImplementedException();
        }
    }
}
