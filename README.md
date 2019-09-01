# ApiFactory.ReturnAlways
Return models standardization for dotnet core web apis. 

## How to use

```sh
[HttpPost("create")]
public async Task<IActionResult> CreateUser([FromBody] User user)
{
   /// your code
   return ReturnAs.Created(newUser);
}

 
----------result will be  

{ 
   "success":true,
   "statusCode":201,
   "responseData":{ 
    ////  ... your result json ... 
 }
}

```


```sh
[HttpGet]
public async Task<IActionResult> GetPagerList()
{
    ///some code
    return ReturnAs.OkList(list, list.Count());
}

------- result will be

{ 
   "success":true,
   "statusCode":200,
   "type":"list",
   "count":3,
   "pager":{ 
      "totalCount":3,
      "pageSize":10,
      "totalPageCount":1,
      "currentPageNumber":1,
      "currentRowCount":3
   },
   "responseData":[ 
      --- your result data ---
   ]
}
```

### How to use on Errors

```sh
[HttpPost]
public async Task<IActionResult> Login(string username, string password)
{
    if(string.isNullOrEmpty(password))
        return ReturnAs.BadRequest("Password is null");
    
    return ReturnAs.Ok();
}
       
------- result will be

{ 
   "success":false,
   "statusCode":400,
   "message":"Password is null"
}


```
