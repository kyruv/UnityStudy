from django.db import models

# This sets up the database - you are welcome to make this much 
# more modularized and custom. I opt to just stick all the 
# necessary data for a user into one large table with lots of columns.

class User(models.Model):
    readonly_fields =['created_at', 'updated_at']

    user_id = models.CharField(max_length=200, primary_key=True)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    # game data
    game_score = models.FloatField(blank=True, null=True)
    game_time = models.FloatField(blank=True, null=True)

    # survey data
    s1_q1 = models.CharField(blank=True, null=True, max_length=10)
    s1_q2 = models.IntegerField(blank=True, null=True)

    # survey#2 data
    s2_q1 = models.IntegerField(blank=True, null=True)
    



