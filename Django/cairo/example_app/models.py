from django.db import models

# This sets up the database - you are welcome to make this much 
# more modularized and custom. I opt to stick the game data in a
# json and all the survey answers in their own top level field.

class FlappyBirdStudyResult(models.Model):
    readonly_fields =['created_at', 'updated_at']

    user_id = models.CharField(max_length=200, primary_key=True)
    prolific_id = models.CharField(blank=True, null=True, max_length=200)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    # If there is a variable amount of data to be stored, JSONField is a good choice
    # If there isn't, using multiple primative fields is better
    game_data = models.JSONField(blank=True, null=True)

    # survey data
    s1_name = models.CharField(blank=True, null=True, max_length=100)
    s1_color = models.CharField(blank=True, null=True, max_length=25)

    s2_opinion = models.CharField(blank=True, null=True, max_length=1000)

    s3_preference = models.CharField(blank=True, null=True, max_length=25)



    



