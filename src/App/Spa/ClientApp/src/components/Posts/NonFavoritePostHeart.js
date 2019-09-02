import React from 'react'

const NonFavoritePostHeart = (props) => {
	return (
		<div onClick={() => props.favoritePost()}>
			<i className="fa fa-heart-o" aria-hidden="true"> </i>
		</div>
	);
};

export default NonFavoritePostHeart;