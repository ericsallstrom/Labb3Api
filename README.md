# Labb 3 - API
## School Project for Edugrade .NET23 - Webbapplikationer i C#, ASP.NET
My solution for Labb 3 - API

## API-anrop
### Hämta alla personer i systemet
GET
```bash
https://localhost:7065/persons
```
```
[
  {
    "personId": 1,
    "firstName": "Eric",
    "lastName": "Sällström",
    "dateOfBirth": "1991-01-05T00:00:00",
    "phoneNumber": "0725522355",
    "email": "eric.sallstrom@gmail.com",
    "hobbies": [
      {
        "hobbyId": 1,
        "title": "Fishing",
        "description": "Fishing is a timeless pastime that combines relaxation, skill, and appreciation for nature.",
        "webLinks": [
          {
            "webLinkId": 1,
            "url": "https://www.fishingguideinsweden.com/sv-SE"
          },
          {
            "webLinkId": 2,
            "url": "https://siljanfishing.se/?lang=en#/"
          },
          {
            "webLinkId": 3,
            "url": "https://www.scandinavianwilderness.com/sv/fishing-in-dalarna/"
          }
        ]
      },
      {
        "hobbyId": 6,
        "title": "Cooking",
        "description": "Cooking is the art and science of preparing food. It involves various techniques, ingredients, and creativity to create delicious and satisfying dishes.",
        "webLinks": []
      },
      {
        "hobbyId": 9,
        "title": "Playing Musical Instruments",
        "description": "Playing musical instruments is a fulfilling hobby that allows individuals to express themselves creatively through music. Whether it's strumming a guitar, tickling the ivories of a piano, or blowing a saxophone, playing musical instruments offers relaxation, joy, and a sense of accomplishment.",
        "webLinks": []
      },
      {
        "hobbyId": 10,
        "title": "Hiking",
        "description": "Hiking is a wonderful outdoor activity that allows you to explore nature, stay active, and enjoy breathtaking scenery.",
        "webLinks": [
          {
            "webLinkId": 4,
            "url": "https://visitsweden.com/what-to-do/nature-outdoors/hiking/top-hiking-routes-sweden/"
          },
          {
            "webLinkId": 5,
            "url": "https://www.visitdalarna.se/en/hiking"
          },
          {
            "webLinkId": 6,
            "url": "https://www.alltrails.com/sv-se/sweden/dalarna"
          }
        ]
      }
    ]
  },
  {
    "personId": 2,
    "firstName": "Amanda",
    "lastName": "Jonsson",
    "dateOfBirth": "1989-10-20T00:00:00",
    "phoneNumber": "0701234567",
    "email": "amanda.jonsson@gmail.com",
    "hobbies": [
      {
        "hobbyId": 5,
        "title": "Producing Music",
        "description": "Producing music is an art form where creativity meets technology. It involves composing melodies, arranging sounds, and mixing tracks to create captivating music compositions.",
        "webLinks": []
      },
      {
        "hobbyId": 7,
        "title": "Gardening",
        "description": "Gardening is a rewarding hobby that involves cultivating and nurturing plants, flowers, and vegetables in outdoor or indoor spaces. It provides relaxation, exercise, and the joy of watching things grow.",
        "webLinks": []
      },
      {
        "hobbyId": 8,
        "title": "Photography",
        "description": "Photography is a creative hobby that allows individuals to capture and preserve moments, emotions, and scenes through the lens of a camera. It combines technical skills with artistic vision to create compelling images.",
        "webLinks": []
      },
      {
        "hobbyId": 11,
        "title": "Traveling",
        "description": "Traveling is an enriching experience that allows you to explore new cultures, cuisines, and landscapes. It broadens your horizons, creates lifelong memories, and fosters personal growth.",
        "webLinks": [
          {
            "webLinkId": 7,
            "url": "https://www.nationalgeographic.com/travel/article/why-travel-should-be-considered-an-essential-human-activity"
          }
        ]
      }
    ]
  }
]
```

### Hämta alla intressen som är kopplade till en specifik person
GET
```bash
https://localhost:7065/persons/1/hobbies
```
```
[
  {
    "hobbyId": 1,
    "title": "Fishing",
    "description": "Fishing is a timeless pastime that combines relaxation, skill, and appreciation for nature.",
    "webLinks": [
      {
        "webLinkId": 1,
        "url": "https://www.fishingguideinsweden.com/sv-SE"
      },
      {
        "webLinkId": 2,
        "url": "https://siljanfishing.se/?lang=en#/"
      },
      {
        "webLinkId": 3,
        "url": "https://www.scandinavianwilderness.com/sv/fishing-in-dalarna/"
      }
    ]
  },
  {
    "hobbyId": 6,
    "title": "Cooking",
    "description": "Cooking is the art and science of preparing food. It involves various techniques, ingredients, and creativity to create delicious and satisfying dishes.",
    "webLinks": []
  },
  {
    "hobbyId": 9,
    "title": "Playing Musical Instruments",
    "description": "Playing musical instruments is a fulfilling hobby that allows individuals to express themselves creatively through music. Whether it's strumming a guitar, tickling the ivories of a piano, or blowing a saxophone, playing musical instruments offers relaxation, joy, and a sense of accomplishment.",
    "webLinks": []
  },
  {
    "hobbyId": 10,
    "title": "Hiking",
    "description": "Hiking is a wonderful outdoor activity that allows you to explore nature, stay active, and enjoy breathtaking scenery.",
    "webLinks": [
      {
        "webLinkId": 4,
        "url": "https://visitsweden.com/what-to-do/nature-outdoors/hiking/top-hiking-routes-sweden/"
      },
      {
        "webLinkId": 5,
        "url": "https://www.visitdalarna.se/en/hiking"
      },
      {
        "webLinkId": 6,
        "url": "https://www.alltrails.com/sv-se/sweden/dalarna"
      }
    ]
  }
]
```

### Hämta alla länkar som är kopplade till en specifik person
GET
```bash
https://localhost:7065/persons/1/hobbies
```
```
[
  {
    "webLinkId": 1,
    "url": "https://www.fishingguideinsweden.com/sv-SE",
    "hobbyTitle": "Fishing"
  },
  {
    "webLinkId": 2,
    "url": "https://siljanfishing.se/?lang=en#/",
    "hobbyTitle": "Fishing"
  },
  {
    "webLinkId": 3,
    "url": "https://www.scandinavianwilderness.com/sv/fishing-in-dalarna/",
    "hobbyTitle": "Fishing"
  },
  {
    "webLinkId": 4,
    "url": "https://visitsweden.com/what-to-do/nature-outdoors/hiking/top-hiking-routes-sweden/",
    "hobbyTitle": "Hiking"
  },
  {
    "webLinkId": 5,
    "url": "https://www.visitdalarna.se/en/hiking",
    "hobbyTitle": "Hiking"
  },
  {
    "webLinkId": 6,
    "url": "https://www.alltrails.com/sv-se/sweden/dalarna",
    "hobbyTitle": "Hiking"
  }
]
```

### Koppla en person till ett nytt intresse
POST
```bash
https://localhost:7065/persons/2/hobbies
```
```
{
  "hobbyId": 14,
  "title": "Swimming",
  "description": "Swimming is a versatile activity, offering both recreation and competition. It provides excellent cardiovascular exercise and muscle toning while being enjoyable for all ages. Whether in pools, lakes, or oceans, swimming is a refreshing way to stay active and healthy",
  "webLinks": null
}
```

### Lägga in nya länkar för en specifik person och ett specifikt intresse
POST
```bash
https://localhost:7065/persons/2/hobbies/14/weblinks
```
```
[
  {
    "webLinkId": 0,
    "url": "https://en.wikipedia.org/wiki/Swimming_(sport)"
  }
]
```
