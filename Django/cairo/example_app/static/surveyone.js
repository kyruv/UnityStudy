// Survey JSON
var surveyJSON = {
    title: "Complete this survey to continue to the game.",
    pages: [
        {
            questions: [
                { type: "text", name: "name", title: "Enter your name:" },
                { type: "radiogroup", name: "color", title: "Select your favorite color:", choices: ["Red", "Blue", "Green"] }
            ]
        }
    ]
};

function disable_unity() {
    var canvas = document.getElementById("unity-canvas");
    canvas.style.height = "0";
}

function enable_unity() {
    var canvas = document.getElementById("unity-canvas");
    canvas.style.height = "100%";
}

function start_survey_one(user_id) {
    var canvas = document.getElementById("unity-canvas");

    if (canvas) {
        disable_unity();

        // Initialize Survey
        var survey = new Survey.Model(surveyJSON);

        // Access Survey Responses
        survey.onComplete.add(function (result) {
            console.log("Survey Results:", result.data);
            enable_unity();
            var surveyContainer = document.getElementById("survey1");
            surveyContainer.innerHTML = "";
            var newDataCopy = Object.assign({}, result.data);
            // Add user_id to the new dictionary
            newDataCopy["user_id"] = user_id;
            console.log(newDataCopy);

            fetch(surveyOneUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newDataCopy),
            })
        });

        // Run the Survey
        survey.render("survey1");
        survey.start();
    }

}

