function post_space_survey(user_id) {
    var postGameSurvey = {
        title: "Complete this final Survey ",
        pages: [
            {
                questions: [
                    { type: "radiogroup", name: "preference", title: "Did you prefer clicking or hitting space bar?:", choices: ["Clicking", "Space Bar"] }
                ]
            }
        ]
    };

    var canvas = document.getElementById("unity-canvas");

    if (canvas) {
        disable_unity();

        // Initialize Survey
        var survey = new Survey.Model(postGameSurvey);

        // Access Survey Responses
        survey.onComplete.add(function (result) {
            console.log(result.data);
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

            surveyContainer.innerHTML = "Thank you. You are done with everything. Your confirmation code is 'EXAMPLE_CODE'";
        });

        // Run the Survey
        survey.render("survey");
        survey.start();
    }

}

