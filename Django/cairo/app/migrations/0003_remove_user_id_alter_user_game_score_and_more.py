# Generated by Django 5.0 on 2023-12-15 22:25

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('app', '0002_alter_user_game_score_alter_user_game_time_and_more'),
    ]

    operations = [
        migrations.RemoveField(
            model_name='user',
            name='id',
        ),
        migrations.AlterField(
            model_name='user',
            name='game_score',
            field=models.FloatField(blank=True, null=True),
        ),
        migrations.AlterField(
            model_name='user',
            name='game_time',
            field=models.FloatField(blank=True, null=True),
        ),
        migrations.AlterField(
            model_name='user',
            name='s1_q1',
            field=models.CharField(blank=True, max_length=10, null=True),
        ),
        migrations.AlterField(
            model_name='user',
            name='s1_q2',
            field=models.IntegerField(blank=True, null=True),
        ),
        migrations.AlterField(
            model_name='user',
            name='s2_q1',
            field=models.IntegerField(blank=True, null=True),
        ),
        migrations.AlterField(
            model_name='user',
            name='user_id',
            field=models.CharField(max_length=200, primary_key=True, serialize=False),
        ),
    ]
