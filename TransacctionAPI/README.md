# ASP.NET Core WebApi Transactions

We emulate debit and credit operations for a single user, so we always have just one financial account. 

## Swagger

``` https://localhost:44354/index.html```

![All the Methods](../Images/01.png)
![Schemas](../Images/04.png)

## GET all Transactions

``` https://localhost:44354/Transaction ```

![ASPNETCOREWebAPIGET](../Images/02.png)
![ASPNETCOREWebAPIGETEXAMPLE](../Images/06.png)

## Add new Transaction

``` https://localhost:44354/Transaction```

```javascript
  {
       "description": "payment",
       "amount": 1000,
       "accountNumber": 789456123698,
       "beneficiaryName": "Ely Mejia",
       "bank": "Example",
       "type": 0   
  }
```
Note: If the type field is 0, the value is Debit, otherwise if it is 1 the value is Credit

![ASPNETCOREWebAPIPOST](../Images/03.png)
![ASPNETCOREWebAPIPOSTEXAMPLE](../Images/05.png)

