function pre_game_survey(user_id) {
    var preGameSurvey = {
        title: "Complete this survey to continue to the game.",
        pages: [
            {
                questions: [
                    { type: "text", name: "name", title: "Enter your name:" },
                    { type: "text", name: "prolific_id", title: "Enter your prolific id:" },
                    { type: "radiogroup", name: "color", title: "Select your favorite color:", choices: ["Red", "Blue", "Green"] }
                ]
            }
        ]
    };

    var canvas = document.getElementById("unity-canvas");

    if (canvas) {
        disable_unity();

        // Initialize Survey
        var survey = new Survey.Model(preGameSurvey);

        // Access Survey Responses
        survey.onComplete.add(function (result) {
            console.log(result.data);

            enable_unity();
            var surveyContainer = document.getElementById("survey");
            surveyContainer.innerHTML = "";
            var newDataCopy = Object.assign({}, result.data);
            // Add user_id to the new dictionary
            newDataCopy["user_id"] = user_id;

            fetch(preGameSurveyUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(newDataCopy),
            })
        });

        // Run the Survey
        survey.render("survey");
        survey.start();
    }

}

