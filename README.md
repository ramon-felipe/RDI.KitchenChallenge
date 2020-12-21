#Kitchen Project
This project simulates a kitchen preparing some dishes.

It receive one or more orders and each order must have one or more items

##Usage

Call the endpoint /Kitchen/MakeOrder passing the order(s) with item(s).
An example below of a json body request containing two orders, the first one wit two items and the second with only one.

```
[
  {
    "items": [
      {
        "type": 2,
        "size": 2,
        "description": "Fries",
        "price": 20,
        "cookTime": 1000
      },
      {
        "type": 1,
        "size": 3,
        "description": "Some drink",
        "price": 20,
        "cookTime": 1000
      }
    ]
  },
  {
    "items": [
      {
        "type": 3,
        "size": 0,
        "description": "Meat grilled",
        "price": 20,
        "cookTime": 1000
      }
    ]
  }
]
```


