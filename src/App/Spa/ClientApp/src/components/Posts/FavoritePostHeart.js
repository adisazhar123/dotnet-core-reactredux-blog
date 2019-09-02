import React from 'react'

const FavoritePostHeart = (props) => {
	return (
		<div onClick={() => props.favoritePost()}>
			<i className="fa fa-heart" aria-hidden="true"> </i>
		</div>
	);
};

export default FavoritePostHeart;