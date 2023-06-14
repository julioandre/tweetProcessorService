import http from 'k6/http'

export function populateTimelineLoadTest(){
   
    var processor = {
        followers: ["001dc4b4-6372-4d2b-af60-2b588d7b8f07",
            "00a7bca3-ce62-4809-bbfe-9a7c5152ced7",
            "050de526-2171-41b3-a49e-33a03798e807",
            "05c6573f-0e08-4015-abd9-1ae99d01676a",
            "05e553aa-1e5f-42ca-aa11-fca7cb9e0554",
            "06ea270b-10d2-4bc4-9b01-8fbdf156695d",
            "079e9702-c074-4efe-a39e-32a2ceae9a6d",
            "07e8fde5-49cf-471d-86e7-042f59b34519",
            "09810aef-1c94-4674-8df2-5c42e301d362",
            "09ff49da-0f9b-46b4-bb51-76067dcbb891"],
        tweet:{
            id: "string",
            userID: "1578a169-ad22-4c46-9b6a-d8702ea2c48d",
            creationTime: "2023-06-14T21:36:58.258Z",
            tweet: "string Load testing tweets processor",
            imageURL: "string.url"

        }
    }
    http.post(`http://localhost:5106/api/tweetProcessor/populateTimeline`,JSON.stringify(processor))
}