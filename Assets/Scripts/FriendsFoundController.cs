using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsFoundController : MonoBehaviour
{
    public List<Vector2> distances = new List<Vector2>() {new Vector2(.75f, .75f)};
    private List<FriendAIController> friends = new List<FriendAIController>();
    public void RemoveFriend(FriendAIController ctx) {
        friends.Remove(ctx);
    }
    public void AddFriend(FriendAIController friend)
    {
        if (!friends.Contains(friend))
        {
            if (friends.Count > 0 && !friends[0].gameObject.Equals(friend.gameObject))
            {
                friend.player = friends[friends.Count - 1].gameObject;
            }
            friends.Add(friend);
            if (friends.Count > 0)
            {
                friends[0].player = gameObject;
            }
            for (int i = 0; i < distances.Count; i++)
            {
                if (friends.Count > i)
                {
                    friends[i].distance = distances[i];
                }
            }
        }
    }
}
