import React, { useState } from 'react';

const TrackingComponent = ({ page }) => {
  const [clickCount, setClickCount] = useState(0);
  const [hoverCount, setHoverCount] = useState(0);

  const trackClick = () => {
    setClickCount(prevCount => prevCount + 1);
    sendTrackingData('/api/tracking/click');
  };

  const trackHover = () => {
    setHoverCount(prevCount => prevCount + 1);
    sendTrackingData('/api/tracking/hover');
  };

  const sendTrackingData = (endpoint) => {
    console.log("is fetching")
    fetch(`http://localhost:5141${endpoint}`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        Page: page,
      }),
    })
    .then(response => {
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => console.log('Tracking data sent successfully:', data))
    .catch(error => console.error('Error sending tracking data:', error));
  };

  return (
    <div>
      <button onClick={trackClick} onMouseEnter={trackHover}>
        Track Me
      </button>
      <div>
        <p>Page: {page}</p>
        <p>Click Count: {clickCount}</p>
        <p>Hover Count: {hoverCount}</p>
      </div>
    </div>
  );
};

export default TrackingComponent;
