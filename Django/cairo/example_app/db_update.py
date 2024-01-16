from django.db import models
from example_app.models import User

def get_user(user_id):
    try:
        obj = User.objects.get(user_id=user_id)
        return obj
    except User.DoesNotExist:
        return User.objects.create(user_id=user_id)


def save_game_data(user_id, score, time):
    user = get_user(user_id)

    user.game_score = score
    user.game_time = time

    user.save()

def save_s1_data(user_id, s1_q1, s1_q2):
    user = get_user(user_id)

    user.s1_q1 = s1_q1
    user.s1_q2 = s1_q2

    user.save()

def save_s2_data(user_id, s2_q1):
    user = get_user(user_id)

    user.s2_q1 = s2_q1

    user.save()

    